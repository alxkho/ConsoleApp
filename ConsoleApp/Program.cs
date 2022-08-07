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

            Console.WriteLine("--------------------------------\n"+
                              "Введите номер задачи (1,2,3)\n" +
                              "--------------------------------");
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
                    Console.WriteLine("\n--------------------------------\n" +
                                      "Чтобы выйти, нажмите Enter\n" +
                                      "--------------------------------");
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
            Console.WriteLine("--------------------------------\n" +
                              "Задача 1\n" +
                              "--------------------------------");

            var values = GetValues(2);
            string value1 = values[0];
            string value2 = values[1];

            value1 += value2;
            value2 = value1.Substring(0, value1.Length - value2.Length);
            value1 = value1.Substring(value2.Length);

            Console.WriteLine($"Результат:\nТеперь 1 - {value1}, 2 - {value2}\n");
        }

        //2
        public static void CompareNumbers(int? value1 = null, int? value2 = null)
        {
            Console.WriteLine("--------------------------------\n" +
                              "Задача 2 (чтобы выйти, не вводите значения)\n" +
                              "--------------------------------");

            var values = GetValues(2);

            if (values[0] == "" || values[1] == "")
                return;

            try
            {
                value1 = Convert.ToInt32(values[0]);
                value2 = Convert.ToInt32(values[1]);
                var sign = value1 == value2 ? "=" : value1 > value2 ? ">" : "<";

                Console.WriteLine($"Результат:\n{value1} {sign} {value2}\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n!!\nВведите число\n!!\n");
            }

            CompareNumbers(value1, value2);
        }

        //3
        public static void IsNumberPalindrome()
        {
            Console.WriteLine("--------------------------------\n" +
                              "Задача 3\n" +
                              "--------------------------------");
            try
            {
                string value = GetValues(1)[0];

                if (value == "")
                    return;

                var number = Convert.ToInt32(value);
                var revers = 0;

                while(number > 0)
                {
                    revers = revers * 10 + number % 10;
                    number /= 10;
                }

                bool result = Convert.ToInt32(value) == revers;

                Console.WriteLine($"Введенное число {value}{(result ? "" : " не")} является полиндромом");
            }
            catch (Exception)
            {
                Console.WriteLine("\n!!\nВведите число\n!!\n");
                IsNumberPalindrome();
            }
        }
    }
}
