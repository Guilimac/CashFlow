using CashFlow.MemoryDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.MemoryDb
{
    public class RegisterDb : IRegisterDb
    {
        private IEnumerable<Register> _Registers;

        public IEnumerable<Register> Registers()
        {
            return _Registers;
        }
    }
}
