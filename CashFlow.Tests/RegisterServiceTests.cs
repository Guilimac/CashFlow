using CashFlow.MemoryDb;
using CashFlow.MemoryDb.Entities;
using CashFlow.Services;
using CashFlow.Tests.Shared;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CashFlow.Tests.Unit
{
    [Trait(nameof(RegisterService),"")]
    public class RegisterServiceTests
    {
        [Fact]
        public void MustReturnResults() {

            var mockDb = new RegisterDbMockBuilder();
            var instance = new RegisterService(mockDb.Instance);
            instance.GetRegister(A.Dummy<Guid>());
            instance.Should().NotBeNull();
        
        }
        [Fact]
        public void MustAddRegister()
        {
            var register = A.Dummy<Register>();
            var instance = new RegisterService(new RegisterDb());
            instance.AddRegister(register);
            instance.GetAllRegisters().Count().Should().Be(1); 
        }
        [Fact]
        public void ShouldRemoveRegister()
        {
            var register = new Register()
            {
                Id = Guid.NewGuid(),
                Value = 10,
                Description = "teste"
            };
            var instance = new RegisterService(new RegisterDb());
            instance.AddRegister(register);
            instance.RemoveRegister(register.Id);
            instance.GetAllRegisters().Count().Should().Be(0);
        }
        [Fact]
        public void ShouldReturnRegisterByDate()
        {
            var register = new Register()
            {
                Id = Guid.NewGuid(),
                Value = 10,
                Description = "teste",
            };
            var instance = new RegisterService(new RegisterDb());
            instance.AddRegister(register);
            var result = instance.GetRegistersByDate(DateTime.Now.Date);
            result.Registers.Count().Should().Be(1);

        }
        [Fact]
        public void MustUpdateRegister()
        {
            var register = new Register()
            {
                Id = Guid.NewGuid(),
                Value = 10,
                Description = "teste",
            };
            var instance = new RegisterService(new RegisterDb());
            instance.AddRegister(register);
            register.Value = 8;
            instance.UpdateRegister(register);
            instance.GetRegister(register.Id).Value.Should().Be(8);
        }
    }
}
