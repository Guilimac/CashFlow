using CashFlow.MemoryDb;
using CashFlow.MemoryDb.Entities;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Tests.Shared
{
    public class RegisterDbMockBuilder : BaseMockBuilder<IRegisterDb>, IBuilder<IRegisterDb>
    {
        private static readonly Expression<Func<IRegisterDb, IEnumerable<Register>>>
            GetRegisters = x => x.Registers();

        public IEnumerable<Register> Registers { get; set; } = A.Dummy<IEnumerable<Register>>();
        internal override Fake<IRegisterDb> BuildMock()
        {
            var mock = new Fake<IRegisterDb>();

            mock.CallsTo(GetRegisters)
                .WithAnyArguments()
                .Returns(Registers);

            return mock;
        }
    }
}
