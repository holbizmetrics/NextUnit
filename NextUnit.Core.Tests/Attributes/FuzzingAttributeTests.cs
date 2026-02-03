using NextUnit.Core.Asserts;
using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class FuzzingAttributeTests
    {
        [Test]
        [Group(nameof(FuzzingAttribute))]
        [Fuzzing]
        public void FuzzingAttributeTest(int n1, int n2)
        {
            int result = n1 + n2;

            if (n1 == int.MaxValue && n2 == int.MaxValue)
            {
                Assert.IsFalse(result == -2);
            }
            System.Console.WriteLine($"n1 + n2: {result}");
        }
    }
}
