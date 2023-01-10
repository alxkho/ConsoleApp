namespace Coursework
{
    public class Seat
    {
        public string Number { get; set; }
        public SeatType Type { get; set; }
        public bool IsBooking { get; set; }

        public Seat()
        {

        }

        public Seat(string number, SeatType type)
        {
            Number = number;
            Type = type;
            IsBooking = false;
        }
    }

    enum SeatNumber
    {
        A = 1,
        B,
        C,
        D,
        E,
        F,
    }

    public enum SeatType
    {
        BusinessClass,
        PremiumEconomyClass,
        EconomyClass,
        None
    }
}