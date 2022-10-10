namespace HomeWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var card = new CreditCard(100);
            var client = new Client();

            card.CardActionHandler(client.PrintMessage);
            card.Put(40);
            card.Get(200);

            card.CardActionHandler(delegate (string message, int sum) { Console.WriteLine($"{message}\nТекущий баланс {sum} р.\n"); });
            card.Get(50);
            card.Put(80);

            card.CardActionHandler((message, sum) => Console.WriteLine($"{message}\nТекущий баланс {sum} р.\n"));
            card.Get(1);
            card.Put(0);
        }
    }
}