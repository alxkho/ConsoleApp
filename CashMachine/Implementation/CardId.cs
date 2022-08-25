using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Implementation
{
    public class CardId
    {
        public int Id { get; set; }
        public int BankId { get; private set; }
        public int CardType { get; private set; } 

        public static CardId CreateCardId(string cardId)
        {
            string[] ids = cardId.Split('-');
            return new CardId()
            {
                Id = Convert.ToInt32(ids[0]),
                BankId = Convert.ToInt32(ids[1]),
                CardType = Convert.ToInt32(ids[2]),
            };

        }

        public override string ToString()
        {
            return $"{Id:D4}-{BankId:D2}-{CardType:D1}";
        }
    }
}
