namespace Coursework
{
    public class Route : IdName
    {
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public double TotalTime { get; set; }

        public Route(int id, string name, Airport departureAirport, Airport arrivalAirport, double totalTime) : base(id, name)
        {
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            TotalTime = totalTime;
        }
    }
}
