using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class SkipAttributeTests
    {
        [Test]
        [Skip("Demonstrating skip functionality")]
        public void SkipThisTest()
        {

        }
    }
}
