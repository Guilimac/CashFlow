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
        public RegisterDb()
        {
            _Registers = new List<Register>();
        }
        private IEnumerable<Register> _Registers;

        public IEnumerable<Register> Registers()
        {
            return _Registers;
        }

        public void setRegiters(List<Register> registers)
        {
            _Registers = registers;
        }
    }
}
