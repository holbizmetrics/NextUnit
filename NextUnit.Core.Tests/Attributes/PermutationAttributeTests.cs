using NextUnit.Core.TestAttributes;
using System.Diagnostics;

namespace NextUnit.Core.Tests.Attributes
{
    public class PermutationAttributeTests
    {
        [Test]
        [Permutation]
        [Group(nameof(PermutationAttribute))]
        public void PermutationAttributeTest(int a, int b)
        {
            Trace.WriteLine($"Output{a}, {b}");
        }
    }
}
