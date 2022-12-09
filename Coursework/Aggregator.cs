namespace Coursework
{
    public class Aggregator : IdName
    {
        List<AirTicket> airTickets = new();
        List<AirTicket> cart = new();
        List<Flight> flights = new();
        

        public Aggregator(int id, string name) : base(id, name)
        {
        }

        public void CreateTickets()
        {
            //Planes
            Plane boing737 = new Plane(1, "Boing 737", "Boing", 2020, 162, TransportationType.International, FlightRange.LongHaul);
            Plane boing747 = new Plane(2, "Boing 747", "Boing", 2021, 352, TransportationType.International, FlightRange.LongHaul);
            Plane embraer170 = new Plane(3, "Embraer 170", "Embraer", 2017, 72, TransportationType.Regional, FlightRange.ShortHaul);
            Plane boing757 = new Plane(4, "Boing 757", "Boing", 2020, 162, TransportationType.International, FlightRange.LongHaul);

            //Airlines
            Airline belavia = new Airline(1, "Belavia", "Belarus", AirlineType.International);
            Airline virginAtlantic = new Airline(2, "Virgin Atlantic", "United Kingdom", AirlineType.Continental);
            Airline aeroflot = new Airline(3, "Aeroflot", "Russia", AirlineType.International);
            Airline uralAirlines = new Airline(4, "Ural AirLines", "Russia", AirlineType.Charter);

            //Airports
            Airport msq = new Airport(1, "MSQ", "Belarus", "Minsk");
            Airport mow = new Airport(2, "MOW", "Russia", "Moscow");
            Airport tbs = new Airport(3, "TBS", "Georgia", "Tbilisi");

            //Routes
            Route route1 = new Route(1, "MM1", msq, mow, 1.30);
            Route route2 = new Route(2, "MT1", msq, tbs, 1.30);
            Route route3 = new Route(3, "MMT1", mow, tbs, 1.30);

            //Flights
            Flight flight1 = new Flight(1, "flight1", new DateTime(2022, 11, 20, 12, 00, 00), belavia, boing747, route1);
            Flight flight2 = new Flight(2, "flight2", new DateTime(2022, 11, 25, 16, 00, 00), virginAtlantic, embraer170, route2);
            Flight flight3 = new Flight(3, "flight3", new DateTime(2022, 11, 25, 18, 00, 00), belavia, boing737, route1);
            Flight flight4 = new Flight(4, "flight4", new DateTime(2022, 11, 20, 15, 00, 00), aeroflot, boing757, route1);

            flights.AddRange(new List<Flight>() { flight1, flight2, flight3, flight4 });
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Добро пожаловать в {Name}!");
            MainProcess();
        }

        public void MainProcess()
        {
            var loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("Выберите, что бы хотели сделать.\n0 - Выйти\n1 - Купить авиабилет\n2 - Посмотреть купленные билеты,\n4 - Оплатить");
                    if (!int.TryParse(Console.ReadLine(), out int answer))
                        continue;
                    switch (answer)
                    {
                        case (int)UserAnswer.Exit:
                            Console.WriteLine("Всего доброго!");
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
                            loop = false;
                            break;
                        default:
                            throw new Exception("Данный вариант не найден.");
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
                    Console.WriteLine("0 - Назад,\n1 - Найти рейс,\n2 - Посмотреть список всех рейсов,\n3 - Ввести номер рейса,\n4 - Оплатить");
                    if (!int.TryParse(Console.ReadLine(), out int answer))
                        continue;
                    switch (answer)
                    {
                        case (int)UserAnswer.Back:
                            MainProcess();
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
                            break;
                        case (int)UserAnswer.Pay:
                            ToPayTickets();
                            loop = false;
                            break;
                        default:
                            throw new Exception("Данный вариант не найден.");
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
                Console.WriteLine($"Вы выбрали рейс - {flight.Name}");
                var loop = true;
                while (loop)
                {

                    Console.WriteLine("0 - Назад,\n1 - Выбрать место,\n2 - Посмотреть все места,\n4 - Оплатить");
                    if (!int.TryParse(Console.ReadLine(), out int answer))
                        continue;
                    switch (answer)
                    {
                        case (int)UserAnswer.Back:
                            ToBuyTickets();
                            loop = false;
                            break;
                        case (int)UserAnswer.InputSeatNumber:
                            InputSeatNumber(flight);
                            loop = false;
                            break;
                        case (int)UserAnswer.GetAllSeats:
                            flight.Plane.GetPlaneSeats();
                            break;
                        case (int)UserAnswer.Pay:
                            ToPayTickets();
                            loop = false;
                            break;
                        default:
                            throw new Exception("Данный вариант не найден.");
                    }
                }
            }
            catch (Exception e)
            {
                WriteException(e.Message);
            }
        }

        public void InputSeatNumber(Flight flight, List<AirTicket> oldcart = null)
        {
            if (oldcart != null)
                cart.AddRange(oldcart);

            var loop = true;
            while (loop)
            {
                try
                {
                    Console.Write("Введите номер места: ");
                    var seatNumber = Console.ReadLine().Trim().ToUpper();
                    if (seatNumber == string.Empty)
                        throw new Exception("Пожалуйста, введите место. Если хотите выйти, введите 0");
                    if (seatNumber == "0")
                        ChooseSeats(flight);
                    var seat = flight.CheckSeat(seatNumber);
                    if (seat == null)
                        throw new Exception("Данное место не найдено или уже занято");
                    if (cart.Any(r => r.Flight == flight && r.Seat.Number == seatNumber))
                        throw new Exception("Вы уже выбрали данное место");

                    var ticket = new AirTicket(flight, seat);
                    cart.Add(ticket);

                    Console.WriteLine("Хотите ли взять еще один билет? 0 - нет, 1 - да");
                    if (!int.TryParse(Console.ReadLine(), out int answer))
                        continue;
                    switch (answer)
                    {
                        case (int)UserAnswer.No:
                            Console.Clear();
                            ToBuyTickets(flight);
                            loop = false;
                            break;
                        case (int)UserAnswer.Yes:
                            break;
                        default:
                            throw new Exception("Данный вариант не найден.");
                    }
                }
                catch (Exception e)
                {
                    WriteException(e.Message);
                }
            }
        }

        public void ToBuyTickets(Flight flight)
        {
            var loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine($"В корзине: {cart.Count} шт.");
                    var total = 0;
                    foreach (var ticket in cart)
                    {
                        total += ticket.Cost;
                        Console.WriteLine("     " + ticket.GetInfo());
                    }
                    Console.WriteLine($"Итого к оплате: {total} р.");
                    Console.WriteLine("0 - Назад,\n1 - Добавить билет,\n2 - Удалить билет,\n3 - Очистить корзину,\n4 - Оплатить");
                    if (!int.TryParse(Console.ReadLine(), out int answer))
                        continue;
                    switch (answer)
                    {
                        case (int)UserAnswer.Back:
                            InputSeatNumber(flight);
                            loop = false;
                            break;
                        case (int)UserAnswer.AddTicket:
                            InputSeatNumber(flight);
                            break;
                        case (int)UserAnswer.RemoveTicket:
                            RemoveTicket();
                            break;
                        case (int)UserAnswer.CleanCart:
                            CleanCart();
                            loop = false;
                            break;
                        case (int)UserAnswer.Pay:
                            ToPayTickets();
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Данный вариант не найден.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    WriteException(e.Message);
                }

            }
        }

        public void ToPayTickets()
        {
            if (cart.Count == 0)
                throw new Exception("Корзина пуста!");

            Console.WriteLine("\nВведите имя: ");
            string fullName = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("Введите телефон: ");
            string phone = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("Введите гражданство: ");
            string citizenship = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("Введите номер паспорта: ");
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
            Console.WriteLine("Билеты куплены");
            Console.ResetColor();
            MainProcess();
        }
        public void SearchFlight()
        {
            Console.Clear();
            Console.Write("Откуда: ");
            var departure = Console.ReadLine().Trim().ToLower();
            Console.Write("\nКуда: ");
            var landing = Console.ReadLine().Trim().ToLower();
            Console.Write("\nДата вылета: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                throw new Exception("Дата введена некорректно");
            var filteredFlights = flights.Where(r => r.Route.DepartureAirport.Name.ToLower() == departure && r.Route.ArrivalAirport.Name.ToLower() == landing && r.DepartureDate.ToShortDateString() == date.ToShortDateString()).ToList();
            GetFlightsInfo(filteredFlights);
        }

        public void ChooseFlight()
        {
            Console.Write("Введите рейс: ");
            var flightName = Console.ReadLine().Trim().ToLower();
            var flight = flights.FirstOrDefault(r => r.Name.ToLower() == flightName);
            if (flight == null)
                throw new Exception("Данный маршрут не найден");
            ChooseSeats(flight);
        }

        public void GetFlightsInfo(List<Flight> airFlights)
        {
            if (airFlights.Count == 0)
                throw new Exception("Информация не найдена.");
            foreach (var flight in airFlights)
            {
                Console.WriteLine(flight.GetInfo());
            }
        }

        public void RemoveTicket()
        {
            Console.Write("Введите номер места: ");
            var seatNumber = Console.ReadLine().Trim().ToLower();
            var seat = cart.FirstOrDefault(r => r.Seat.Number.ToLower() == seatNumber);
            if (seat == null)
                throw new Exception("Данное место не найдено или уже занято");
            if (cart.Remove(seat))
                Console.WriteLine("Билет удален из вашей корзины!");
        }

        public void CleanCart()
        {
            cart.Clear();
            Console.WriteLine("Корзина очищена!");
            ToBuyTickets();
        }

        public void GetBuyTickets()
        {
            if (airTickets.Count == 0)
                throw new Exception("Билеты отсутствуют");
            Console.WriteLine($"\nКуплено: {airTickets.Count}шт.");

            foreach (var ticket in airTickets)
            {
                Console.WriteLine("        " + ticket.GetInfo());
            }
        }

        public void WriteException(string exceptionMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {exceptionMessage}\n");
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
}

