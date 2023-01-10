using System.Text;

namespace Coursework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aggregator aviasales = new Aggregator(1, "Aviasales");
            aviasales.CreateTickets();
            aviasales.Start();
        }
    }
}