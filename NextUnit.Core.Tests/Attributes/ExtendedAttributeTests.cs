using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class ExtendedAttributeTests
    {
        [Test]
        [Group(nameof(ExtendedTestAttribute))]
        [ExtendedTest]
        public void ExtendedAttributeTest(int n1, int n2)
        {
            int result = n1 + n2;
            System.Console.WriteLine($"n1 + n2: {n1 + n2}");
        }
    }
}
