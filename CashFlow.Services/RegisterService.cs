using CashFlow.MemoryDb;
using CashFlow.MemoryDb.Entities;
using CashFlow.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services
{
    public class RegisterService : IRegisterService
    {
        private IRegisterDb _registerDb;
        public RegisterService(IRegisterDb registerDb)

        {
            _registerDb = registerDb;
        }
        public void AddRegister(Register register)
        { 
            var registers = _registerDb.Registers();
            var listRegistes = registers.ToList<Register>();
            register.Id = Guid.NewGuid();
            listRegistes.Add(register);
            _registerDb.SetRegiters(listRegistes);
        }

        public Register GetRegister(Guid id)
        {
            var register = _registerDb.Registers().FirstOrDefault<Register>(r => r.Id == id);
            if (register != null) return register;
            return new Register();
        }

        public RegistersDto GetRegistersByDate(DateTime date)
        {
            var registerDto = new RegistersDto();
            registerDto.Registers = _registerDb.Registers().Where<Register>(r => r.CreatedAt.Date == date.Date);
            registerDto.Total = _registerDb.Registers().Sum<Register>(r => r.Value);
            return registerDto;
        }

        public void RemoveRegister(Guid id)
        {
            var listRegistes = _registerDb.Registers().ToList();
            listRegistes.RemoveAll(r => r.Id == id);
            _registerDb.SetRegiters(listRegistes);
        }

        public void UpdateRegister(Register register)
        {
            var registers = _registerDb.Registers();
            var registerUp = registers.Where<Register>(r => r.Id == register.Id).FirstOrDefault();
            registerUp.Value = register.Value;
            registerUp.Description = register.Description;
            registerUp.UpdatedAt = DateTime.Now;        }

        public IEnumerable<Register> GetAllRegisters()
        {
            return _registerDb.Registers();
        }
    }
}
