using Coursework.Interfaces;
using Coursework.Models;

namespace Coursework.Collections
{
    public class Routes : IMyCollection<Route>
    {
        public List<Route> AllRoutes { get; }
        Airports airports = new();

        public Routes()
        {
            var msq = airports.GetByName("msq");
            var mow = airports.GetByName("mow");
            var tbs = airports.GetByName("tbs");

            Route route1 = new Route(1, "MM1", msq, mow, 1.30);
            Route route2 = new Route(2, "MT1", msq, tbs, 1.30);
            Route route3 = new Route(3, "MMT1", mow, tbs, 1.30);
            AllRoutes = new List<Route>() { route1, route2, route3 };
        }
        public void Add(Route route)
        {
            AllRoutes.Add(route);
        }
        public void Add(int id, string name, string departureAirportName, string arrivalAirportName, double totalTime)
        {
            var departureAirport = airports.GetByName(departureAirportName);
            var arrivalAirport = airports.GetByName(arrivalAirportName);
            AllRoutes.Add(new Route(id, name, departureAirport, arrivalAirport, totalTime));
        }
        public Route? GetByName(string name)
        {
            return AllRoutes.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        public void AddRange(List<Route> routes)
        {
            AllRoutes.AddRange(routes);
        }
    }
}