namespace HomeWork5
{
    public class ExchangeRate
    {
        public Currencies FirstCurrency;
        public Currencies SecondCurrency;
        public float Value;
        public int CurrencyCount = 1;

        public ExchangeRate(Currencies firstCurrency, Currencies secondCurrency)
        {
            FirstCurrency = firstCurrency;
            SecondCurrency = secondCurrency;
        }
        public ExchangeRate(Currencies firstCurrency, Currencies secondCurrency, float value) : this(firstCurrency, secondCurrency)
        {
            Value = value;
        }

        public void SetValue(float value)
        {
            Value = value;
        }
        public void SetCurrencyCount(int currencyCount)
        {
            CurrencyCount = currencyCount;
        }

        public override string ToString()
        {
            return $"{CurrencyCount} {FirstCurrency} = {Value} {SecondCurrency}";
        }
    }
}
