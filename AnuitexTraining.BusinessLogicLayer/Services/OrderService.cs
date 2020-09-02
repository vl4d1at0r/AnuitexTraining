using AnuitexTraining.BusinessLogicLayer.Exceptions;
using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Models.Orders;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static AnuitexTraining.Shared.Constants.Constants;
using static AnuitexTraining.Shared.Enums.Enums;
using Stripe;
using System;
using AnuitexTraining.BusinessLogicLayer.Providers;

namespace AnuitexTraining.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IPaymentRepository _paymentRepository;
        private OrderMapper _orderMapper;
        private OrderItemMapper _orderItemMapper;
        private ExchangeRateProvider _exchangeRateProvider;

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

        public async Task<IPagedList<OrderModel>> GetPageAsync(OrderModel filter, int page, int pageSize)
        {
            // UNDONE: Show user's orders if not admin
            List<DataAccessLayer.Entities.Order> orders = await _orderRepository.GetAllAsync();
            orders = orders.Where(item =>
            {
                if (item.Description.ToLower().Contains(filter.Description.ToLower()) &&
                    (item.CreationDate.CompareTo(filter.CreationDate) == 0 || filter.CreationDate == default) &&
                    (item.Date.CompareTo(filter.Date) == 0 || filter.Date == default) &&
                    (item.PaymentId.ToString().Contains(filter.PaymentId.ToString()) || filter.PaymentId == default) &&
                    (item.UserId == filter.UserId || filter.UserId == default) &&
                    (item.Status == filter.Status || filter.Status == OrderStatus.None))
                {
                    return true;
                }
                return false;
            }).ToList();
            List<OrderModel> models = _orderMapper.Map(orders);
            models.ForEach(item => 
            {
                List<DataAccessLayer.Entities.OrderItem> orderItems = _orderItemRepository.GetByOrderIdAsync(item.Id).Result;
                item.Items = _orderItemMapper.Map(orderItems);
            });
            return models.ToPagedList(page, pageSize);
        }

        public async Task AddAsync(OrderModel orderModel)
        {
            if (orderModel.Date == default)
            {
                orderModel.Errors.Add(ExceptionsInfo.InvalidDate);
            }
            if (orderModel.UserId == default)
            {
                orderModel.Errors.Add(ExceptionsInfo.InvalidUserId);
            }
            if (orderModel.Items == null || !orderModel.Items.Any())
            {
                orderModel.Errors.Add(ExceptionsInfo.EmptyOrder);
            }
            if (orderModel.Description == default)
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
                int index = orderModel.Items.IndexOf(item);
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
                if (item.Currency != CurrencyType.USD)
                {
                    item.Amount = _exchangeRateProvider.ExchangeToUSD(item.Amount, item.Currency);
                    item.Currency = CurrencyType.USD;
                }
            }
            if (orderModel.Errors.Any())
            {
                throw new UserException(HttpStatusCode.BadRequest, orderModel.Errors);
            }
            Payment payment = new Payment();
            await _paymentRepository.AddAsync(payment);
            orderModel.PaymentId = payment.Id;
            var order = _orderMapper.Map(orderModel);
            await _orderRepository.AddAsync(order);
            orderModel.Items.ForEach(item => item.OrderId = order.Id);
            await _orderItemRepository.AddRangeAsync(_orderItemMapper.Map(orderModel.Items));
        }

        public async Task DeleteAsync(long id)
        {
            if ((await _orderRepository.GetAsync(id)) is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidId });
            }
            await _orderItemRepository.DeleteAsync(id);
        }

        public async Task BuyAsync(long id, string transactionToken)
        {
            var order = await _orderRepository.GetAsync(id);
            if (order is null)
            {
                throw new UserException(HttpStatusCode.BadRequest, new List<string> { ExceptionsInfo.InvalidId });
            }
            var orderItems = await _orderItemRepository.GetByOrderIdAsync(id);
            long sum = 0;
            foreach (var item in orderItems)
            {
                sum += Convert.ToInt64(item.Amount.ToString("F").Replace(",", string.Empty));
            }
            ChargeCreateOptions options = new ChargeCreateOptions
            {
                Currency = CurrencyType.USD.ToString(),
                Amount = sum,
                Description = order.Description,
                Source = transactionToken
            };
            ChargeService service = new ChargeService();
            Charge charge = service.Create(options);
            Payment payment = await _paymentRepository.GetAsync(order.PaymentId);
            payment.TransactionId = charge.Id;
            order.Status = OrderStatus.Paid;
            await _orderRepository.UpdateAsync(order);
        }
    }
}
