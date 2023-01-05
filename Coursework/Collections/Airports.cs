using Coursework.Interfaces;
using Coursework.Models;

namespace Coursework.Collections
{
    public class Airports : IMyCollection<Airport>
    {
        public List<Airport> AllAirport { get; }
        public Airports()
        {
            Airport msq = new Airport(1, "MSQ", "Belarus", "Minsk");
            Airport mow = new Airport(2, "MOW", "Russia", "Moscow");
            Airport tbs = new Airport(3, "TBS", "Georgia", "Tbilisi");
            AllAirport = new List<Airport>() { msq, mow, tbs };
        }
        public void Add(Airport airport)
        {
            AllAirport.Add(airport);
        }
        public Airport? GetByName(string name)
        {
            return AllAirport.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        public void AddRange(List<Airport> airports)
        {
            AllAirport.AddRange(airports);
        }
    }
}
