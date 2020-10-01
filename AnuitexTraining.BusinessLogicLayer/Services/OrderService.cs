using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Base;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.BusinessLogicLayer.Providers;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Models;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Stripe;
using static AnuitexTraining.Shared.Constants.Constants;
using static AnuitexTraining.Shared.Enums.Enums;
using Order = AnuitexTraining.DataAccessLayer.Entities.Order;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly ExchangeRateProvider _exchangeRateProvider;
        private readonly OrderItemMapper _orderItemMapper;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly OrderMapper _orderMapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;

        public OrderService(IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            IPaymentRepository paymentRepository,
            OrderMapper orderMapper,
            OrderItemMapper orderItemMapper,
            ExchangeRateProvider exchangeRateProvider)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _paymentRepository = paymentRepository;
            _orderMapper = orderMapper;
            _orderItemMapper = orderItemMapper;
            _exchangeRateProvider = exchangeRateProvider;
        }

        public async Task<IEnumerable<OrderModel>> GetPageAsync(PageModel<OrderModel> orderPageModel, bool admin, long userId)
        {
            var orderPage = new PageOptions<Order>
            {
                Filter = _orderMapper.Map(orderPageModel.Filter),
                Page = orderPageModel.Page,
                PageSize = orderPageModel.PageSize,
                SortField = orderPageModel.SortField,
                SortOrder = orderPageModel.SortOrder
            };
            
            var orders = await _orderRepository.GetPageAsync(orderPage, admin, userId);
            var models = _orderMapper.Map(orders);
            models.ForEach(item =>
            {
                var orderItems =
                    _orderItemRepository.GetByOrderIdAsync(item.Id).Result;
                item.Items = _orderItemMapper.Map(orderItems);
            });
            return models;
        }

        public async Task AddAsync(OrderModel orderModel, long userId)
        {
            if (orderModel.Date == default)
            {
                orderModel.Errors.Add(ExceptionsInfo.InvalidDate);
            }

            if (orderModel.Items == null || !orderModel.Items.Any())
            {
                orderModel.Errors.Add(ExceptionsInfo.EmptyOrder);
            }

            if (string.IsNullOrEmpty(orderModel.Description))
            {
                orderModel.Errors.Add(ExceptionsInfo.InvalidDescription);
            }

            if (orderModel.Id != default)
            {
                orderModel.Errors.Add(ExceptionsInfo.InvalidId);
            }

            if (orderModel.PaymentId != default)
            {
                orderModel.Errors.Add(ExceptionsInfo.InvalidPaymentId);
            }

            if (orderModel.Status != OrderStatus.None)
            {
                orderModel.Errors.Add(ExceptionsInfo.InvalidStatus);
            }

            if (orderModel.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, orderModel.Errors);
            }

            foreach (var item in orderModel.Items)
            {
                var index = orderModel.Items.IndexOf(item);
                if (item.Amount == default)
                {
                    orderModel.Errors.Add(string.Format(ExceptionsInfo.InvalidAmount, index));
                }

                if (item.PrintingEditionId == default)
                {
                    orderModel.Errors.Add(string.Format(ExceptionsInfo.InvalidPrintingEditionId, index));
                }

                if (item.Id != default)
                {
                    orderModel.Errors.Add(string.Format(ExceptionsInfo.InvalidItemId, index));
                }

                if (item.OrderId != default)
                {
                    orderModel.Errors.Add(string.Format(ExceptionsInfo.InvalidOrderId, index));
                }

                if (item.Count == default)
                {
                    orderModel.Errors.Add(string.Format(ExceptionsInfo.InvalidCount, index));
                }

                if (item.Currency == default)
                {
                    orderModel.Errors.Add(ExceptionsInfo.InvalidCurrencyType);
                }
            }

            if (orderModel.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, orderModel.Errors);
            }

            orderModel.Items.ForEach(async item =>
            {
                if (item.Currency != CurrencyType.USD)
                {
                    item.Amount = _exchangeRateProvider.ExchangeToUSD(item.Amount, item.Currency);
                    item.Currency = CurrencyType.USD;
                    await _orderItemRepository.UpdateAsync(_orderItemMapper.Map(item));
                }
            });
            orderModel.UserId = userId;
            orderModel.Status = OrderStatus.Unpaid;
            var payment = new Payment();
            await _paymentRepository.AddAsync(payment);
            orderModel.PaymentId = payment.Id;
            var order = _orderMapper.Map(orderModel);
            await _orderRepository.AddAsync(order);
            orderModel.Items.ForEach(item => item.OrderId = order.Id);
            await _orderItemRepository.AddRangeAsync(_orderItemMapper.Map(orderModel.Items));
        }

        public async Task DeleteAsync(long id)
        {
            var order = await _orderRepository.GetAsync(id);
            if (order is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            await _orderRepository.DeleteAsync(id);
        }

        public async Task BuyAsync(long id, string transactionToken)
        {
            var order = await _orderRepository.GetAsync(id);
            if (order is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> {ExceptionsInfo.InvalidId});
            }

            var orderItems = await _orderItemRepository.GetByOrderIdAsync(id);
            long sum = 0;
            foreach (var item in orderItems)
            {
                sum += Convert.ToInt64(item.Amount.ToString("F").Replace(",", string.Empty));
            }

            var options = new ChargeCreateOptions
            {
                Currency = CurrencyType.USD.ToString(),
                Amount = sum,
                Description = order.Description,
                Source = transactionToken
            };
            var service = new ChargeService();
            var charge = service.Create(options);
            var payment = await _paymentRepository.GetAsync(order.PaymentId);
            payment.TransactionId = charge.Id;
            order.Status = OrderStatus.Paid;
            await _orderRepository.UpdateAsync(order);
        }
    }
}