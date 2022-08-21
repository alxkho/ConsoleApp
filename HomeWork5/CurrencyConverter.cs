using System.Text;

namespace HomeWork5
{
    public class CurrencyConverter
    {
        public List<ExchangeRate> ExchangeRates;

        public CurrencyConverter()
        {
            ExchangeRates = new List<ExchangeRate>();
        }

        public void AddExchangeRate(ExchangeRate exchangeRate)
        {
            ExchangeRates.Add(exchangeRate);
        }
        public void AddExchangeRates(ExchangeRate[] exchangeRates) //ExchangeRate[]
        {
            ExchangeRates.AddRange(exchangeRates);
        }

        public void TryDeleteExchangeRate(Currencies firstCurrency, Currencies secondCurrency)
        {
            var rate = FindExchangeRate(firstCurrency, secondCurrency);
            ExchangeRates.Remove(rate);
        }

        public ExchangeRate FindExchangeRate(Currencies firstCurrency, Currencies secondCurrency)
        {
            var rate = ExchangeRates.Find(r => r.FirstCurrency == firstCurrency && r.SecondCurrency == secondCurrency);
            return rate;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            ExchangeRates.ForEach(r =>
            {
                str.Append($"{r.ToString()}\n");
            });

            return str.ToString();
        }

        public ExchangeRate Convert(Currencies CurrcencyFirst, Currencies CurrencySecond, int count)
        {
            ExchangeRate rate = FindExchangeRate(CurrcencyFirst, CurrencySecond);
            if (rate != null)
            {
                var result = (count * rate.Value) / rate.CurrencyCount;
                rate.SetCurrencyCount(count);
                rate.SetValue(result);
            }
            return rate;
        }
    }
}
