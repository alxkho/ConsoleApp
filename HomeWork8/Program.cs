namespace HomeWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyTimer timer = new MyTimer();
            timer.Start(10);
            Console.WriteLine("Hello, World!");
        }
    }
}