using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class DontRunDuringAttributeTests
    {
        [Test]
        [Group(nameof(DontRunDuringAttribute))]
        [DontRunDuring("2024-05-01T00:00:00", "2024-05-01T00:00:00")]
        public void DontRunDuringAttributeTest()
        {

        }
    }
}
