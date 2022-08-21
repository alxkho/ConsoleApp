using System.Text;

namespace HomeWork5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var converter = new CurrencyConverter();
            AddRandomRates(converter);
            Console.WriteLine(converter.ToString());

            Console.WriteLine("Выберите валюту из списка, которую хотите обменять:");
            var currencies = new StringBuilder();
            foreach (var i in Enum.GetNames(typeof(Currencies)))
            {
                currencies.Append($"{i} ");
            }
            Console.WriteLine(currencies.ToString());

            var firstCurrency = (Currencies)Enum.Parse(typeof(Currencies), InputWithValidation(Validation.IsCurrency));

            Console.WriteLine($"\nВыберите валюту, на которую хотите обменять {firstCurrency}:");
            Console.WriteLine(currencies.Replace($"{firstCurrency} ", ""));
            var secondCurrency = (Currencies)Enum.Parse(typeof(Currencies), InputWithValidation(Validation.IsCurrency));

            var currentRate = converter.FindExchangeRate(firstCurrency, secondCurrency);
            Answer answer = Answer.None;
            if (currentRate == null)
            {
                Console.Write($"Такого курса не существует. Хотите его добавить? 1 - да, 0 - нет ");
                answer = (Answer)Enum.Parse(typeof(Answer), Console.ReadLine().ToUpper());
                if (Answer.Yes == answer)
                {
                    Console.WriteLine($"Введите курс обмена {firstCurrency} - {secondCurrency}");
                    var value = (float)Convert.ToDouble(InputWithValidation(Validation.IsNumber));

                    converter.AddExchangeRate(new ExchangeRate(firstCurrency, secondCurrency, value));
                }
            }
            else
                Console.WriteLine($"\nТекущий курс: {currentRate.ToString()}");

            if (answer != Answer.No)
            {
                Console.Write($"Введите кол-во {firstCurrency}: ");
                var count = Convert.ToInt32(InputWithValidation(Validation.IsNumber));

                var resultRate = converter.Convert(firstCurrency, secondCurrency, count);
                Console.WriteLine(resultRate.ToString());

            }
            Console.ReadLine();
        }

        public static void AddRandomRates(CurrencyConverter converter)
        {
            var exchangeRates = new ExchangeRate[10];
            Random rand = new Random();
            for (int i = 0; i < exchangeRates.Length; i++)
            {
                var randCurrency = (Currencies)rand.Next(9);
                var value = randCurrency == (Currencies)i ? 1 : (float)Math.Round((rand.NextDouble() + 2), 2);
                exchangeRates[i] = new ExchangeRate((Currencies)i, randCurrency, value);
            }
            converter.AddExchangeRates(exchangeRates);
        }

        public static string InputWithValidation(Validation validation)
        {
            var str = Console.ReadLine().ToUpper();
            bool condition;
            string textError;

            if (validation == Validation.IsCurrency)
                textError = "Такой валюты нет в списке";
            else
                textError = "Введите число!";

            while (validation == Validation.IsCurrency ? !Enum.IsDefined(typeof(Currencies), str) : !double.TryParse(str, out var i))
            {
                Console.WriteLine(textError);
                str = Console.ReadLine().ToUpper();
            }

            return str;
        }

        public enum Validation
        {
            IsCurrency,
            IsNumber
        }

        public enum Answer
        {
            No,
            Yes,
            None
        }
    }
}