using CashMachine.Abstractions;
using CashMachine.Implementation;

namespace Lesson9
{
    internal class ATMWorker
    {
        
        private List<Atm> _atms;
        private Atm _currentAtm;
        private Random _rand;

        public ATMWorker()
        {
            _atms = new List<Atm>();
            _currentAtm = new AtmFirm1();
        }
        public void StartWork()
        {
            Console.WriteLine("Добро пожаловать! Введите ID карты(0000-00-0)");
            string cardId = Console.ReadLine();
            //_currentAtm = _atms[_rand.Next(0, _atms.Count - 1)];
            if (_currentAtm.SetCard(cardId))
            {
                Console.WriteLine("Введите пароль");
                string password = Console.ReadLine();
                if (_currentAtm.CheckPassword(password))
                {
                    StartSession();
                    EndSession();
                }

            }


        }

        private void GenerateItems()
        {

        }

        private void StartSession()
        {
            Console.WriteLine(@"Операции АТМ: 
                                    1 - Выдача наличных
                                    2- занесение наличных на счет" + Environment.NewLine);


            while (true)
            {
                string operationId = Console.ReadLine();
                if (Enum.TryParse(operationId, out ATMOperationEnum operation))
                {
                    switch (operation)
                    {
                        case ATMOperationEnum.GetCash:
                            break;
                        case ATMOperationEnum.PutCash:
                            Console.WriteLine("Введите значение для выдачи");
                            string cashValue = Console.ReadLine();
                            Console.WriteLine($"Выдано: {_currentAtm.GetCash(Convert.ToInt32(cashValue))}");
                            break;
                        case ATMOperationEnum.Exit:
                            return;
                        default:
                            Console.WriteLine("Попробуйте еще раз");
                            break;
                    }
                }
            }


        }

        private void EndSession()
        {

        }
    }
}
