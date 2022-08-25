namespace HomeWork9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите имя файла: ");
                string? fileName = Console.ReadLine();
                if (fileName == "")
                    return;
                FileParser? parser = FileParser.GetParser(fileName);
                if (parser == null)
                    Console.WriteLine("Парсер для данного файла не был найден! Попробуйте снова!");
                else
                    parser.Parse();
                Console.WriteLine();
            }
        }
    }
}