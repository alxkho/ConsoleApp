using CashMachine.Interfaces;

namespace CashMachine.Abstractions
{
    public abstract class Atm : ICashMachine
    {
        protected Bank _bank;
        protected Card _currentCard;
        protected bool _isPasswordCorrect;
        protected abstract int Delay { get; set; }

        public Atm()
        {
            _currentCard = new Card();
        }

        public bool CheckPassword(string password)
        {
            //return _currentCard.CheckPassword(password);
            return true;
        }

        public void GetCard()
        {
            throw new NotImplementedException();
        }

        public string GetCardInfo()
        {
            throw new NotImplementedException();
        }

        public virtual int GetCash(int cashValue)
        {
            Console.WriteLine(this);
            Thread.Sleep(Delay);
            return _currentCard.GetCash(cashValue);
        }

        public string GetCashStatus()
        {
            throw new NotImplementedException();
        }

        public void PushCash(int cashValue)
        {
            throw new NotImplementedException();
        }

        public bool SetCard(string cardId)
        {
            //Выполнить поиск карты по ID
            _currentCard = null;
            return true;
        }

        public void TransferCash(int cashValue, string cardId)
        {
            throw new NotImplementedException();
        }
    }
}
