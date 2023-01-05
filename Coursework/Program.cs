using Coursework.Collections;

namespace Coursework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var planes = new Planes();
            var airlines = new Airlines();
            var routes = new Routes();
            Flights flights = new Flights(planes, airlines, routes);

            Aggregator aviasales = new Aggregator(1, "Aviasales", flights.AllFlights);
            aviasales.Start();
        }
    }
}