using System.Net;
using AnuitexTraining.BusinessLogicLayer.Models.ExchangeRate;
using Newtonsoft.Json;
using static AnuitexTraining.Shared.Enums.Enums;

namespace AnuitexTraining.BusinessLogicLayer.Providers
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
            return value / (double) _exchangeRate.conversion_rates.GetType().GetProperty(currencyType.ToString())
                .GetValue(_exchangeRate.conversion_rates);
        }
    }
}