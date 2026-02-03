using NextUnit.Core.Asserts;
using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class InjectDataAttributeTests
    {
        public const bool TestInjectDataAttribute_isEnabled = true;
        public const int TestInjectDataAttribute_count = 5;
        public const string TestInjectDataAttribute_message = "Crazy. It works!";
        /// <summary>
        /// This will test that data can be injected and is correctly contained.
        /// </summary>
        [Test]
        [Group(nameof(InjectDataAttribute))]
        [InjectData(TestInjectDataAttribute_message, TestInjectDataAttribute_count, TestInjectDataAttribute_isEnabled)]
        [InjectData("Crazy. It works!", 7, false)]
        [InjectData("This as well!", 3, false)]
        public void TestInjectDataAttributeTest(string message, int count, bool isEnabled)
        {
            Assert.IsTrue(message == TestInjectDataAttribute_message);
            Assert.IsTrue(count == TestInjectDataAttribute_count);
            Assert.IsTrue(isEnabled == TestInjectDataAttribute_isEnabled);
        }

        [Test]
        [Group(nameof(InjectDataAttribute))]
        [InjectData(1, 2, 3, "Name", false)]
        public void InjectDataAttributeTest(int intParam1, int intParam2, int intParam3, string name, bool @switch)
        {
            Assert.AreEqual(1, intParam1);
            Assert.AreEqual(2, intParam2);
            Assert.AreEqual(3, intParam3);
            Assert.AreEqual("Name", name);
            Assert.AreEqual(@switch, @switch);
        }
    }
}
