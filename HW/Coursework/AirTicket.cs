namespace Coursework
{
    public class AirTicket : IGetInfo
    {
        long Id { get; set; }
        public Flight Flight { get; set; }
        public string SeatNumber { get; set; }
        public Seat Seat { get; set; }
        public int Cost { get; set; } 
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Citizenship { get; set; }
        public string NumberOfPassport { get; set; }

        public AirTicket(Flight flight)
        {
            Flight = flight;
        }

        public AirTicket(Flight flight, Seat seat)
        {
            Flight = flight;
            Seat = seat;
            Cost = Seat.Type == SeatType.BusinessClass ? 50 : Seat.Type == SeatType.PremiumEconomyClass ? 35 : 25;
        }

        public AirTicket(int id, Seat seat, int cost, SeatType type, Flight flight)
        {
            Id = id;
            Seat = seat;
            Cost = cost;
            Flight = flight;
        }

        public void Buy()
        {
            Seat.IsBooking = true;
        }

        public string GetInfo()
        {
            return $"{Flight.Name} {Flight.DepartureDate} {Flight.Route.DepartureAirport}-{Flight.Route.ArrivalAirport} Место: {Seat.Number} - {Cost}";
        }
    }
}