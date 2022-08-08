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
            string task = null;

            while (task != "")
            {
                Console.WriteLine("--------------------------------\n" +
                                  "Введите номер задачи (1,2,3)\n" +
                                  "--------------------------------");
                task = Console.ReadLine();
                Console.WriteLine("");
                GetTask(task);
            }
        }

        public static void GetTask(string task)
        {
            switch (task)
            {
                case "1":
                    ReplaceValues();
                    break;
                case "2":
                    CompareNumbers();
                    break;
                case "3":
                    IsNumberPalindrome();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такой задачи нет\n");
                    Console.ResetColor();
                    break;
            }
        }

        public static List<int> GetValues(int count)
        {
            var values = new List<int>();

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Console.WriteLine($"Введите значение {i + 1}");
                    var value = Console.ReadLine();
                    Console.WriteLine("");
                    if (value == "")
                        break;
                    var num = Convert.ToInt32(value);
                    values.Add(num);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!!\nВведите число\n!!\n");
                    Console.ResetColor();
                    i--;
                }
            }

            return values;
        }

        //1
        public static void ReplaceValues()
        {
            Console.WriteLine("--------------------------------\n" +
                              "Задача 1\n" +
                              "--------------------------------");

            var values = GetValues(2);

            if (values.Count == 0)
                return;

            int num1 = values[0];
            int num2 = values[1];

            num1 += num2;
            num2 = num1 - num2;
            num1 = num1 - num2;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Результат:\nТеперь 1 - {num1}, 2 - {num2}\n");
            Console.ResetColor();
        }

        //2
        public static void CompareNumbers(int? value1 = null, int? value2 = null)
        {
            Console.WriteLine("--------------------------------\n" +
                              "Задача 2 (чтобы выйти, не вводите значения)\n" +
                              "--------------------------------");

            var values = GetValues(2);

            if (values.Count == 0)
                return;

            value1 = values[0];
            value2 = values[1];
            var sign = value1 == value2 ? "=" : value1 > value2 ? ">" : "<";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Результат:\n{value1} {sign} {value2}\n");
            Console.ResetColor();

            CompareNumbers(value1, value2);
        }

        //3
        public static void IsNumberPalindrome()
        {
            Console.WriteLine("--------------------------------\n" +
                              "Задача 3\n" +
                              "--------------------------------");

            var value = GetValues(1);

            if (value.Count == 0)
                return;

            var number = value[0];
            var revers = 0;

            while (number > 0)
            {
                revers = revers * 10 + number % 10;
                number /= 10;
            }

            bool result = value[0] == revers;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Введенное число {value[0]}{(result ? "" : " не")} является полиндромом\n");
            Console.ResetColor();
        }
    }
}

