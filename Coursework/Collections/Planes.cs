using Coursework.Interfaces;
using Coursework.Models;

namespace Coursework.Collections
{
    public class Planes : IMyCollection<Plane>
    {
        public List<Plane> AllPlanes { get; }
        public Planes()
        {
            Plane boing737 = new Plane(1, "Boing 737", "Boing", 2020, 162, TransportationType.International, FlightRange.LongHaul);
            Plane boing747 = new Plane(2, "Boing 747", "Boing", 2021, 352, TransportationType.International, FlightRange.LongHaul);
            Plane embraer170 = new Plane(3, "Embraer 170", "Embraer", 2017, 72, TransportationType.Regional, FlightRange.ShortHaul);
            Plane boing757 = new Plane(4, "Boing 757", "Boing", 2020, 162, TransportationType.International, FlightRange.LongHaul);
            AllPlanes = new List<Plane>() { boing737, boing747, embraer170, boing757 };
        }
        public void Add(Plane plane)
        {
            AllPlanes.Add(plane);
        }
        public Plane? GetByName(string name)
        {
            return AllPlanes.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        public void AddRange(List<Plane> planes)
        {
            AllPlanes.AddRange(planes);
        }
    }
}