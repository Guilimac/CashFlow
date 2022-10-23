using CashFlow.MemoryDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.MemoryDb
{
    public interface IRegisterDb
    {
        public IEnumerable<Register> Registers();
        public void SetRegiters(List<Register> registers);
    }
}
