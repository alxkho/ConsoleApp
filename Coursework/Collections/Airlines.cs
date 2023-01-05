using Coursework.Interfaces;
using Coursework.Models;

namespace Coursework.Collections
{
    public class Airlines : IMyCollection<Airline>
    {
        public List<Airline> AllAirline { get; }
        public Airlines()
        {
            Airline belavia = new Airline(1, "Belavia", "Belarus", AirlineType.International);
            Airline virginAtlantic = new Airline(2, "Virgin Atlantic", "United Kingdom", AirlineType.Continental);
            Airline aeroflot = new Airline(3, "Aeroflot", "Russia", AirlineType.International);
            Airline uralAirlines = new Airline(4, "Ural AirLines", "Russia", AirlineType.Charter);
            AllAirline = new List<Airline>() { belavia, virginAtlantic, aeroflot, uralAirlines };
        }
        public void Add(Airline airline)
        {
            AllAirline.Add(airline);
        }
        public Airline? GetByName(string name)
        {
            return AllAirline.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        public void AddRange(List<Airline> airlines)
        {
            AllAirline.AddRange(airlines);
        }
    }
}
