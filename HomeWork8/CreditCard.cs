namespace HomeWork8
{
    public delegate void AccountAction(string message, int sum);
    public class CreditCard
    {
        public int Sum { get; private set; }
        //public event AccountAction? CardEvent;
        AccountAction? action;


        public CreditCard(int sum)
        {
            Sum = sum;
        }

        public void CardActionHandler(AccountAction? someAction)
        {
            action = someAction;
            //CardEvent = someAction;
        }

        public void Get(int money)
        {
            if (money <= Sum)
            {
                Sum -= money;
                action?.Invoke($"Вы сняли {money} р.", Sum);
                //CardEvent?.Invoke($"Вы сняли {money} р.", Sum);
            }
            else
            {
                action?.Invoke($"Недостаточно средств", Sum);
                //CardEvent?.Invoke($"Недостаточно средств", Sum);
            }
        }

        public void Put(int money)
        {
            Sum += money;
            action?.Invoke($"Вы положили {money} р.", Sum);
            //CardEvent?.Invoke($"Вы положили {money} р.", Sum);
        }
    }
}
