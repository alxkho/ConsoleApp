namespace HomeWork8.Delegate
{
    public class Client
    {
        public void PrintMessage(string message, int sum) => Console.WriteLine($"{message}\nТекущий баланс {sum} р.\n");
    }
}
