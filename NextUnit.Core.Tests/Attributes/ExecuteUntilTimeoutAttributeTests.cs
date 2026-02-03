using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class ExecuteUntilTimeoutAttributeTests
    {
        [Test]
        [Group("ExecuteUntilTimeoutAttribute")]
        [ExecuteUntilTimeout("00:00:01", "00:00:01")]
        public void ExecuteUntilTimeoutAttributeTest()
        {
        }
    }
}
