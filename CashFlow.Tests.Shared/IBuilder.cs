using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Tests.Shared
{
    public interface IBuilder<T>
    {
        public T Instance { get; }
    }
}
