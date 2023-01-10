namespace Coursework
{
    public class Plane : IdName
    {
        string Manufacturer { get; set; }
        int Year { get; set; }
        public int CountPlaces { get; set; }
        TransportationType TransportationType { get; set; }
        FlightRange FlightRange { get; set; }

        private int SeatsInRow = 6;

        List<Seat> BusinessSeats = new();
        List<Seat> PEconomySeats = new();
        List<Seat> EconomySeats = new();
        public List<Seat> AllSeats = new();

        public Plane(int id, string name, string manufacturer, int year, int countPlaces, TransportationType transportationType, FlightRange flightRange) : base(id, name)
        {
            Manufacturer = manufacturer;
            Year = year;
            CountPlaces = countPlaces;
            TransportationType = transportationType;
            FlightRange = flightRange;

            RandomSetSeats();
        }

        public void CreateSeats(int businessSeats, int pEconomySeats, int economySeats)
        {
            if (businessSeats + pEconomySeats + economySeats > CountPlaces)
                throw new Exception("");
            var businessRows = (businessSeats / 4);
            var allRows = (CountPlaces - businessSeats) / SeatsInRow + businessRows;
            for (int i = 1; i <= allRows; i++)
            {
                for (int j = 1; j <= SeatsInRow; j++)
                {
                    Seat seat = new Seat { Number = $"{(SeatNumber)j}{i}" };
                    if (i <= businessRows)
                    {
                        if (j == SeatsInRow / 2 || j == SeatsInRow / 2 + 1)
                        {
                            seat.Type = SeatType.None;
                            BusinessSeats.Add(seat);
                            continue;
                        }
                        seat.Type = SeatType.BusinessClass;
                        BusinessSeats.Add(seat);
                    }
                    else if (i <= businessRows + pEconomySeats / SeatsInRow)
                    {
                        seat.Type = SeatType.PremiumEconomyClass;
                        PEconomySeats.Add(seat);
                    }
                    else
                    {
                        seat.Type = SeatType.EconomyClass;
                        EconomySeats.Add(seat);
                    }
                }
            }
        }

        public void RandomSetSeats()
        {
            Random rnd = new Random();
            var business = CountPlaces * rnd.Next(2, 5) / 100;
            business -= business % SeatsInRow;
            var pEconomy = (CountPlaces - business) * rnd.Next(30, 35) / 100;
            pEconomy -= pEconomy % SeatsInRow;

            var economy = CountPlaces - business - pEconomy;

            CreateSeats(business, pEconomy, economy);
            AllSeats = BusinessSeats.Concat(PEconomySeats).Concat(EconomySeats).ToList();
        }

        public void GetPlaneSeats()
        {
            var seats = new Dictionary<SeatNumber, List<Seat>>();

            Console.Write("\n  ");
            for (int j = 1; j <= CountPlaces / 6; j++)
            {
                Console.Write(j + (j < 10 ? "  " : " "));
            }
            Console.WriteLine("");

            for (int i = 1; i <= typeof(SeatNumber).GetEnumValues().Length; i++)
            {
                seats[(SeatNumber)i] = AllSeats.Where(r => r.Number.Contains(((SeatNumber)i).ToString())).ToList();
                Console.Write((SeatNumber)i + " ");
                seats[(SeatNumber)i].ForEach(r =>
                {
                    Console.ForegroundColor = r.IsBooking ? ConsoleColor.DarkRed
                                                : r.Type switch
                                                {
                                                    SeatType.BusinessClass => ConsoleColor.Yellow,
                                                    SeatType.PremiumEconomyClass => ConsoleColor.Cyan,
                                                    _ => ConsoleColor.Blue,
                                                };
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.Write(r.Type != SeatType.None ? (r.IsBooking ? '□' : '■') + "- " : "   ");
                    Console.ResetColor();
                });
                if (i == SeatsInRow / 2)
                    Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nБизнес-класс");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Эконом-плюс");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Эконом-класс\n");
            Console.ResetColor();
        }
    }

    public enum FlightRange
    {
        LongHaul,
        MediumHaul,
        ShortHaul,
        LocalAircraft
    }

    public enum TransportationType
    {
        International,
        Regional,
        Local,
    }
}