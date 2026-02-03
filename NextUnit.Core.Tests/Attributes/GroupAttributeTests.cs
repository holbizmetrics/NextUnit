using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class GroupAttributeTests
    {
        [Test]
        [Group(nameof(GroupAttribute))]
        public void GroupAttributeTest()
        {

        }
    }
}
