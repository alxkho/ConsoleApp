using CashMachine.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Abstractions
{
    public class Card
    {
        private CardId cardId;
        private int _cashValue;
        private string _password;
        private string _userName;

        public int AddCash(int cashValue) => _cashValue = cashValue;

        public int GetCash(int cashValue)
        {
            if (cashValue > _cashValue)
                throw new Exception("У вас недостаточно средств");

            return _cashValue -= cashValue;
        }

        public bool CheckPassword(string password) => password.CompareTo(_password) == 0;
    }
}
