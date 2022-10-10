namespace HomeWork8
{
    public class MyTimer
    {
        public static void Start()
        {
            TimerCallback timer = new TimerCallback(PrintTime);
            Timer time = new Timer(timer, null, 0, 1000);
            Console.ReadLine();
        }

        static void PrintTime(object temp)
        {
            Console.Clear();
            Console.WriteLine("Текущее время: " + DateTime.Now.ToLongTimeString());
        }
    }
}
