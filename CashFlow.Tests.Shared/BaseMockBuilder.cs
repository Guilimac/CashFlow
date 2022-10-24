using FakeItEasy;

namespace CashFlow.Tests.Shared
{
    public abstract class BaseMockBuilder<T> where T : class
    {
        private Fake<T> InstanceMock { get; set; }
        /// <summary>
        /// Returns the mock object.
        /// </summary>
        public Fake<T> Mock
        {
            get
            {
                if (InstanceMock == null)
                {
                    InstanceMock = BuildMock();
                }

                return InstanceMock;
            }
        }
        /// <summary>
        /// Exposes the mocked instance.
        /// </summary>
        public T Instance
        {
            get
            {
                return Mock.FakedObject;
            }
        }

        internal abstract Fake<T> BuildMock();
    }
}
