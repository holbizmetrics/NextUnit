using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class RunBeforeAttributeTests
    {
        [Test]
        [Group(nameof(RunBeforeAttribute))]
        [RunBefore("2030-12-31T23:59:59")]
        public void RunBeforeAttributeTest()
        {

        }
    }
}
