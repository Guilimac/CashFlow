using CashFlow.MemoryDb.Entities;
using CashFlow.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services
{
    public interface IRegisterService
    {
        public Register GetRegister(Guid id);
        public RegistersDto GetRegistersByDate(DateTime date);
        public void AddRegister(Register register);
        public void RemoveRegister(Guid id);    
        public void UpdateRegister(Register register);


    }
}
