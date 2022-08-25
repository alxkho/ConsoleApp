using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Interfaces
{
    public interface ICashMachine
    {
        //проверяте наичие карты в бд
        bool SetCard(string cardId);
        void GetCard();
        bool CheckPassword(string password);
        int GetCash(int cashValue);
        void PushCash(int cashValue);
        void TransferCash(int cashValue, string cardId);
        string GetCashStatus();
        string GetCardInfo();

    }

}
