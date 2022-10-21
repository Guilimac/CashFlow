using CashFlow.MemoryDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services.Dtos
{
    public class RegistersDto
    {
        public IEnumerable<Register>? Registers { get; set; }
        public float Total { get; set; }
    }
}
