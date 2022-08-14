namespace HomeWork4
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
                    CreateArray();
                    break;
                case "2":
                    CreateMatrix();
                    break;
                case "3":
                    CreateDictionary();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такой задачи нет\n");
                    Console.ResetColor();
                    break;
            }
        }

        public static List<int> GetSize(int count)
        {
            var values = new List<int>();

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Console.WriteLine($"Введите размер массива {i + 1}");
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

        public static void CreateArray()
        {
            Console.WriteLine("--------------------------------\n" +
                             "Задача 1 (массив)\n" +
                             "--------------------------------");

            var size = GetSize(1);
            if (size.Count == 0)
                return;

            int[] arr = new int[size[0]];
            int[] sortArr = arr;
            var max = arr[0];
            var min = arr[0];
            var sum = 0;

            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }
            Console.WriteLine($"Массив - {string.Join(" ", arr)}");

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];

                if (arr[i] < min)
                    min = arr[i];

                sum += arr[i];
            }

            //sort
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        sortArr[j] = arr[j + 1];
                        sortArr[j + 1] = temp;
                    }
                }
            }

            var average = sum / arr.Length;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Сумма - {sum}");
            Console.WriteLine($"Максимальное - {max}");
            Console.WriteLine($"Минимальное - {min}");
            Console.WriteLine($"Среднее арифметическое - {average}");
            Console.WriteLine($"Отсортированный массив - {string.Join(" ", sortArr)}");
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void CreateMatrix()
        {
            Console.WriteLine("--------------------------------\n" +
                             "Задача 2 (матрица)\n" +
                             "--------------------------------");

            var size = GetSize(2);

            if (size.Count == 0)
                return;

            var rows = size[0];
            var cols = size[1];

            int[,] matrix = new int[rows, cols];

            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(-100, 100);
                }
            }

        }

        static void CreateDictionary()
        {
            Console.WriteLine("--------------------------------\n" +
                              "Задача 3 (переводчик)\n" +
                              "--------------------------------");

            var dict = new Dictionary<string, string>()
            {
                { "dictionary", "словарь"},
                { "variable", "переменная"},
                { "string", "строка"},
                { "warning", "предупреждение"},
                { "error", "ошибка"},
                { "bug", "ошибка"},
                { "debugger", "отладчик"},
                { "access", "доступ"},
                { "run", "запускать"},
                { "matrix", "матрица"}
            };

            Console.WriteLine("Введите слово");
            var word = Console.ReadLine().ToLower();

            if (dict.ContainsKey(word))
                Console.WriteLine($"{word} - {dict[word]}");
            else
                Console.WriteLine("Слово не было найдено\n");
        }
    }
}
