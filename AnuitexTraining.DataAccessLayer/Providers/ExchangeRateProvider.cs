using System;
using System.Net;
using AnuitexTraining.DataAccessLayer.Models.ExchangeRate;
using Newtonsoft.Json;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.DataAccessLayer.Providers
{
    public class ExchangeRateProvider
    {
        private readonly ExchangeRateModel _exchangeRate;

        public ExchangeRateProvider()
        {
            using var client = new WebClient();
            var json =
                client.DownloadString("https://v6.exchangerate-api.com/v6/f32774e0581819e2bbf8ced6/latest/USD");
            _exchangeRate = JsonConvert.DeserializeObject<ExchangeRateModel>(json);
        }

        public double ExchangeToUSD(double value, CurrencyType currencyType)
        {
            return Math.Round(value / (double) _exchangeRate.conversion_rates.GetType().GetProperty(currencyType.ToString())
                .GetValue(_exchangeRate.conversion_rates), 2, MidpointRounding.AwayFromZero); // 2 stands for count of numbers after point
        }

        public double Exchange(CurrencyType from, CurrencyType to, double value)
        {
            double result = value / (double) _exchangeRate.conversion_rates.GetType().GetProperty(from.ToString())
                .GetValue(_exchangeRate.conversion_rates);
            result = result * (double) _exchangeRate.conversion_rates.GetType().GetProperty(to.ToString())
                .GetValue(_exchangeRate.conversion_rates);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero); // 2 stands for count of numbers after point
        }
    }
}