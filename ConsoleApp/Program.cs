using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetTask();
        }

        public static void GetTask()
        {

            Console.WriteLine("--------------------------------\n"+"Введите номер задачи (1,2,3)");
            Console.WriteLine("--------------------------------");
            string task = Console.ReadLine();
            Console.WriteLine("");

            switch (task)
            {
                case "1":
                    ReplaceValues();
                    GetTask();
                    break;
                case "2":
                    CompareNumbers();
                    GetTask();
                    break;
                case "3":
                    IsNumberPalindrome();
                    GetTask();
                    break;

                case "":
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Чтобы выйти, нажмите Enter");
                    Console.WriteLine("--------------------------------");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Такой задачи нет"); ;
                    GetTask();
                    break;
            }
        }

        public static List<string> GetValues(int count)
        {
            var values = new List<string>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите значение {i + 1}");
                var value = Console.ReadLine();
                values.Add(value);
                Console.WriteLine("");
            }

            return values;
        }

        //1
        public static void ReplaceValues()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Задача 1");
            Console.WriteLine("--------------------------------");

            var values = GetValues(2);
            string value1 = values[0];
            string value2 = values[1];

            value1 += value2;
            value2 = value1.Substring(0, value1.Length - value2.Length);
            value1 = value1.Substring(value2.Length);

            Console.WriteLine("Результат:");
            Console.WriteLine($"Теперь 1 - {value1}, 2 - {value2}");
            Console.WriteLine("");
        }

        //2
        public static void CompareNumbers(int? value1 = null, int? value2 = null)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Задача 2 (чтобы выйти, не вводите значения)");
            Console.WriteLine("--------------------------------");

            var values = GetValues(2);

            if (values[0] == "" && values[1] == "")
                return;

            try
            {
                value1 = Convert.ToInt32(values[0]);
                value2 = Convert.ToInt32(values[1]);
                var sign = value1 == value2 ? "=" : value1 > value2 ? ">" : "<";

                Console.WriteLine("Результат:");
                Console.WriteLine($"{value1} {sign} {value2}");
                Console.WriteLine("");
            }
            catch (Exception)
            {
                Console.WriteLine("");
                Console.WriteLine("!!");
                Console.WriteLine("Введите число");
                Console.WriteLine("!!");
                Console.WriteLine("");
            }

            CompareNumbers(value1, value2);

        }

        //3
        public static void IsNumberPalindrome()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Задача 3");
            Console.WriteLine("--------------------------------");

            try
            {
                string value = GetValues(1)[0];

                if (value == "")
                    return;

                if (!int.TryParse(value, out int r))
                    throw new Exception();

                var part1 = value.Substring(0, value.Length / 2);
                var part2 = value.Substring((value.Length / 2) + 1);

                bool result = part1 == string.Join("", part2.Reverse().ToArray());

                Console.WriteLine($"Введенное число {value}{(result ? "" : " не")} является полиндромом");
            }
            catch (Exception)
            {
                Console.WriteLine("");
                Console.WriteLine("!!");
                Console.WriteLine("Введите число");
                Console.WriteLine("!!");
                Console.WriteLine("");
                IsNumberPalindrome();
            }
        }
    }
}
