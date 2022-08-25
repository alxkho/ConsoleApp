using CashMachine.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Implementation
{
    public class AtmFirm2: Atm
    {
        protected override int Delay { get; set; } = 10000;
    }
}
