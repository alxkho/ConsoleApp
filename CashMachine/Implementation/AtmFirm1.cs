using CashMachine.Abstractions;

namespace CashMachine.Implementation
{
    public class  AtmFirm1 : Atm
    {
        protected override int Delay { get; set; } = 100;
        public AtmFirm1()
        {

        }
    }
}
