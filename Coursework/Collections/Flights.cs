using Coursework.Interfaces;
using Coursework.Models;

namespace Coursework.Collections
{
    public class Flights : IMyCollection<Flight>
    {
        public List<Flight> AllFlights { get; }
        public Flights(Planes planes, Airlines airlines, Routes routes)
        {
            Flight flight1 = new Flight(1, "flight1", new DateTime(2022, 11, 20, 12, 00, 00), airlines.GetByName("belavia"), planes.GetByName("boing 747"), routes.GetByName("MM1"));
            Flight flight2 = new Flight(2, "flight2", new DateTime(2022, 11, 25, 16, 00, 00), airlines.GetByName("virginAtlantic"), planes.GetByName("embraer 170"), routes.GetByName("MT1"));
            Flight flight3 = new Flight(3, "flight3", new DateTime(2022, 11, 25, 18, 00, 00), airlines.GetByName("belavia"), planes.GetByName("boing 737"), routes.GetByName("MMT1"));
            Flight flight4 = new Flight(4, "flight4", new DateTime(2022, 11, 20, 15, 00, 00), airlines.GetByName("aeroflot"), planes.GetByName("boing 757"), routes.GetByName("MM1"));

            AllFlights = new List<Flight>() { flight1, flight2, flight3, flight4 };
        }
        public void Add(Flight Flight)
        {
            AllFlights.Add(Flight);
        }
        public Flight? GetByName(string name)
        {
            return AllFlights.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        public void AddRange(List<Flight> Flights)
        {
            AllFlights.AddRange(Flights);
        }
    }
}