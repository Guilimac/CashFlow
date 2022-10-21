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
            throw new NotImplementedException();
        }

        public Register GetRegister(Guid id)
        {
            var register = _registerDb.Registers().FirstOrDefault<Register>(r => r.Id == id);
            if (register == null) return register;
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
            var registers = _registerDb.Registers().Where(r => r.Id == id).ToList<Register>();
            registers.RemoveAll(r => r.Id == id);
        }

        public void UpdateRegister(Register register)
        {
            _registerDb.Registers().Where(r=>r.Id == register.Id).ToList<Register>().Select(r => { r.Value = register.Value; r.Description = register.Description; r.UpdatedAt = DateTime.Now; return r; });
        }
    }
}
