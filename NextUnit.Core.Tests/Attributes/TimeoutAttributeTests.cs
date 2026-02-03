using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class TimeoutAttributeTests
    {
        /// <summary>
        /// This test has to fail if it takes longer than n ms to execute. [Timeout(n)]
        /// </summary>
        [Test]
        [Timeout(1000)]
        public void TimeoutTest()
        {

        }
    }
}
