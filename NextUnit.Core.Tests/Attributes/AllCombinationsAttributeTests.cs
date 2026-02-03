using NextUnit.Core.TestAttributes;
using System.Diagnostics;

namespace NextUnit.Core.Tests.Attributes
{
    public class AllCombinationsAttributeTests
    {
        private bool MyConditionMethod(object[] combination)
        {
            // Your condition logic here...
            return combination[0] is int x && x > 0;
        }

        [Test, AllCombinations(
            conditionMethodName: nameof(MyConditionMethod),
            strategy: PermutationStrategy.Pairwise
        )]
        [Group(nameof(AllCombinationsAttribute))]
        public void AllCombinationsAttributeTest(
            [Values(1, 2, 3)] int x,
            [Values("A", "B")] string s)
        {
            // Test code here...
            Trace.WriteLine($"x: {x}, s: {s}");
        }

        [Test, AllCombinations(
            conditionMethodName: nameof(MyConditionMethod),
            strategy: PermutationStrategy.Pairwise
        )]
        [Group(nameof(AllCombinationsAttribute))]
        public void AllCombinationsAttributePairwiseTest(
            [Values(1, 2, 3)] int x,
            [Values("A", "B")] string s)
        {
            // Test code here...
            Trace.WriteLine($"x: {x}, s: {s}");
        }
    }
}
