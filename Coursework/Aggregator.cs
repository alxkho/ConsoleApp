using Coursework.Collections;
using Coursework.Models;
using Coursework.Resources;

namespace Coursework
{
    public class Aggregator : IdName
    {
        List<AirTicket> airTickets = new();
        List<AirTicket> cart = new();
        List<Flight> flights = new();


        public Aggregator(int id, string name, List<Flight> flights) : base(id, name)
        {
            this.flights = flights;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"{Texts.WelcomeIn} {Name}!");
            MainProcess();
        }

        public void MainProcess()
        {
            var loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine($"{Texts.ChooseVariant}\n0 - {Variants.Exit}\n1 - {Variants.BuyTickets}\n2 - {Variants.GetBuyTickets},\n4 - {Variants.Pay}");
                    if (!int.TryParse(Console.ReadLine(), out int answer))
                        continue;
                    switch (answer)
                    {
                        case (int)UserAnswer.Exit:
                            Console.WriteLine(Texts.Goodbye);
                            loop = false;
                            break;
                        case (int)UserAnswer.BuyTickets:
                            ToBuyTickets();
                            break;
                        case (int)UserAnswer.GetBuyTickets:
                            GetBuyTickets();
                            break;
                        case (int)UserAnswer.Pay:
                            ToPayTickets();
                            break;
                        default:
                            throw new Exception(Errors.VariantNotFound);
                    }
                }
                catch (Exception e)
                {
                    WriteException(e.Message);
                }
            }
        }

        public void ToBuyTickets()
        {
            Console.Clear();
            var loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine($"0 - {Variants.Back},\n1 - {Variants.SearchFlight},\n2 - {Variants.GetAllFlight},\n3 - {Variants.ChooseFlight},\n4 - {Variants.Pay}");
                    if (!int.TryParse(Console.ReadLine(), out int answer))
                        continue;
                    switch (answer)
                    {
                        case (int)UserAnswer.Back:
                            loop = false;
                            break;
                        case (int)UserAnswer.SearchFlight:
                            SearchFlight();
                            break;
                        case (int)UserAnswer.GetAllFlight:
                            GetFlightsInfo(flights);
                            break;
                        case (int)UserAnswer.ChooseFlight:
                            ChooseFlight();
                            loop = false;
                            break;
                        case (int)UserAnswer.Pay:
                            ToPayTickets();
                            break;
                        default:
                            throw new Exception(Errors.VariantNotFound);
                    }
                }
                catch (Exception e)
                {
                    WriteException(e.Message);
                }
            }
        }

        public void ChooseSeats(Flight flight)
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"{Texts.ChoosedFlight} - {flight.Name}");
                var loop = true;
                while (loop)
                {

                    Console.WriteLine($"0 - {Variants.Back},\n1 - {Variants.InputSeatNumber},\n2 - {Variants.GetAllSeats},\n4 - {Variants.Pay}");
                    if (!int.TryParse(Console.ReadLine(), out int answer))
                        continue;
                    switch (answer)
                    {
                        case (int)UserAnswer.Back:
                            loop = false;
                            break;
                        case (int)UserAnswer.InputSeatNumber:
                            loop = !InputSeatNumber(flight);
                            break;
                        case (int)UserAnswer.GetAllSeats:
                            flight.Plane.GetPlaneSeats();
                            break;
                        case (int)UserAnswer.Pay:
                            ToPayTickets();
                            break;
                        default:
                            throw new Exception(Errors.VariantNotFound);
                    }
                }
            }
            catch (Exception e)
            {
                WriteException(e.Message);
            }
        }

        public bool InputSeatNumber(Flight flight, List<AirTicket> oldcart = null)
        {
            if (oldcart != null)
                cart.AddRange(oldcart);

            var loop = true;
            var result = false;
            while (loop)
            {
                try
                {
                    Console.Write(Texts.ChooseSeat);
                    var seatNumber = Console.ReadLine().Trim().ToUpper();
                    if (seatNumber == string.Empty)
                        throw new Exception($"{Texts.InputSeat} {Texts.WantToExit}");
                    if (seatNumber == "0")
                        loop = false;
                    else
                    {
                        var seat = flight.CheckSeat(seatNumber);
                        if (seat == null)
                            throw new Exception(Errors.SeatNotFound);
                        if (cart.Any(r => r.Flight == flight && r.Seat.Number == seatNumber))
                            throw new Exception(Errors.SeatAlreadyChoose);

                        var ticket = new AirTicket(flight, seat);
                        cart.Add(ticket);

                        Console.WriteLine($"{Texts.ChooseMoreTicket} {Texts.YesNo}");
                        if (!int.TryParse(Console.ReadLine(), out int answer))
                            continue;
                        switch (answer)
                        {
                            case (int)UserAnswer.No:
                                Console.Clear();
                                var booking = ToBuyTickets(flight);
                                loop = booking == Global.Stay;
                                result = booking == Global.Start;
                                break;
                            case (int)UserAnswer.Yes:
                                break;
                            default:
                                throw new Exception(Errors.VariantNotFound);
                        }
                    }
                }
                catch (Exception e)
                {
                    WriteException(e.Message);
                }
            }
            return result;
        }

        public Global ToBuyTickets(Flight flight)
        {
            var loop = true;
            var result = Global.Stay;
            while (loop)
            {
                try
                {
                    Console.WriteLine($"{Texts.InCart} {cart.Count} шт.");
                    var total = 0;
                    foreach (var ticket in cart)
                    {
                        total += ticket.Cost;
                        Console.WriteLine("     " + ticket.GetInfo());
                    }
                    Console.WriteLine($"{Texts.TotalPrice} {total} р.");
                    Console.WriteLine($"0 - {Variants.Back},\n1 - {Variants.AddTicket},\n2 - {Variants.RemoveTicket},\n3 - {Variants.CleanCart},\n4 - {Variants.Pay}");
                    if (!int.TryParse(Console.ReadLine(), out int answer))
                        continue;
                    switch (answer)
                    {
                        case (int)UserAnswer.Back:
                            loop = false;
                            result = Global.Back;
                            break;
                        case (int)UserAnswer.AddTicket:
                            loop = false;
                            break;
                        case (int)UserAnswer.RemoveTicket:
                            RemoveTicket();
                            break;
                        case (int)UserAnswer.CleanCart:
                            CleanCart();
                            break;
                        case (int)UserAnswer.Pay:
                            ToPayTickets();
                            loop = false;
                            result = Global.Start;
                            break;
                        default:
                            Console.WriteLine(Errors.VariantNotFound);
                            break;
                    }
                }
                catch (Exception e)
                {
                    WriteException(e.Message);
                }

            }
            return result;
        }

        public void ToPayTickets()
        {
            if (cart.Count == 0)
                throw new Exception(Errors.CartIsEpmty);

            Console.WriteLine("\n" + Texts.InputName);
            string fullName = Console.ReadLine().Trim().ToLower();
            Console.WriteLine(Texts.InputNumber);
            string phone = Console.ReadLine().Trim().ToLower();
            Console.WriteLine(Texts.InputCitizenship);
            string citizenship = Console.ReadLine().Trim().ToLower();
            Console.WriteLine(Texts.InputPassport);
            string passport = Console.ReadLine().Trim().ToLower();

            cart.ForEach(r =>
            {
                r.FullName = fullName;
                r.PhoneNumber = phone;
                r.Citizenship = citizenship;
                r.NumberOfPassport = passport;
                r.Buy();
            });

            airTickets.AddRange(cart);
            cart.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Texts.TicketsBought);
            Console.ResetColor();
        }
        public void SearchFlight()
        {
            Console.Clear();
            Console.Write(Texts.Departure);
            var departure = Console.ReadLine().Trim().ToLower();
            Console.Write("\n" + Texts.Landing);
            var landing = Console.ReadLine().Trim().ToLower();
            Console.Write("\n" + Texts.DepartureDate);
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                throw new Exception(Errors.WrongDate);
            var filteredFlights = flights.Where(r => r.Route.DepartureAirport.Name.ToLower() == departure && r.Route.ArrivalAirport.Name.ToLower() == landing && r.DepartureDate.ToShortDateString() == date.ToShortDateString()).ToList();
            GetFlightsInfo(filteredFlights);
        }

        public void ChooseFlight()
        {
            Console.Write(Texts.InputFlight);
            var flightName = Console.ReadLine().Trim().ToLower();
            var flight = flights.FirstOrDefault(r => r.Name.ToLower() == flightName);
            if (flight == null)
                throw new Exception(Errors.NotFound);
            ChooseSeats(flight);
        }

        public void GetFlightsInfo(List<Flight> airFlights)
        {
            if (airFlights.Count == 0)
                throw new Exception(Errors.NotFound);
            foreach (var flight in airFlights)
            {
                Console.WriteLine(flight.GetInfo());
            }
        }

        public void RemoveTicket()
        {
            Console.Write(Texts.ChooseSeat);
            var seatNumber = Console.ReadLine().Trim().ToLower();
            var seat = cart.FirstOrDefault(r => r.Seat.Number.ToLower() == seatNumber);
            if (seat == null)
                throw new Exception(Errors.SeatNotFound);
            if (cart.Remove(seat))
                Console.WriteLine(Texts.TicketRemoved);
        }

        public void CleanCart()
        {
            cart.Clear();
            Console.WriteLine(Texts.CartCleaned);
        }

        public void GetBuyTickets()
        {
            if (airTickets.Count == 0)
                throw new Exception(Errors.TicketsNotFound);
            Console.WriteLine($"\n{Texts.TotalBought} {airTickets.Count}шт.");

            foreach (var ticket in airTickets)
            {
                Console.WriteLine("        " + ticket.GetInfo());
            }
        }

        public void WriteException(string exceptionMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Errors.Error}: {exceptionMessage}\n");
            Console.ResetColor();
        }
    }

    enum UserAnswer
    {
        Exit,
        BuyTickets,
        GetBuyTickets,
        Back = 0,
        SearchFlight,
        GetAllFlight,
        ChooseFlight,
        InputSeatNumber = 1,
        GetAllSeats,
        No = 0,
        Yes = 1,
        AddTicket = 1,
        RemoveTicket,
        CleanCart,
        Pay = 4,
    }

    public enum Global
    {
        Stay = 0,
        Back,
        Start
    }
}