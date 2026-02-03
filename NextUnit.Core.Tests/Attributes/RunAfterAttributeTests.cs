using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class RunAfterAttributeTests
    {
        [Test]
        [Group(nameof(RunAfterAttribute))]
        [RunAfter("2024-01-01T00:00:00")]
        public void RunAfterAttributeTest()
        {

        }
    }
}
