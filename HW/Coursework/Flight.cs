namespace Coursework
{
    public class Flight : IdName, IGetInfo
    {
        public DateTime DepartureDate { get; set; }
        DateTime LandingDate { get; set; }
        Airline Airline { get; set; }
        public Plane Plane { get; set; }
        public Route Route { get; set; }

        public Flight(int id, string name, DateTime departureDate, Airline airline, Plane plane, Route route) : base(id, name)
        {
            DepartureDate = departureDate;
            Airline = airline;
            Plane = plane;
            Route = route;
            LandingDate = DepartureDate.AddHours(Route.TotalTime);
        }

        public List<Seat> GetSeatsByClass(SeatType type)
        {
            return Plane.AllSeats.Where(x => x.Type == type).ToList();
        }

        public string GetInfo()
        {
            return $"{Name}: {Route.DepartureAirport.Name} - {Route.ArrivalAirport.Name} {DepartureDate} ";
        }

        public Seat CheckSeat(string number)
        {

            var seat = Plane.AllSeats.Where(r => r.Type != SeatType.None && r.Number.ToLower() == number.ToLower() && !r.IsBooking).FirstOrDefault();
            return seat;
        }
    }
}