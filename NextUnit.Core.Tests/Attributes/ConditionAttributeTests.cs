using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class ConditionAttributeTests
    {
        private bool IsConditionMet()
        {
            // Define your condition logic here
            return true; // Example condition
        }

        [Test]
        [Group(nameof(ConditionAttribute))]
        [Condition(nameof(IsConditionMet))]
        public void ConditionalTest()
        {
            // Test logic here...
        }
    }
}
