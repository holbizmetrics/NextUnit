using NextUnit.Core.Asserts;
using NextUnit.Core.TestAttributes;
using System.Diagnostics;

namespace NextUnit.Core.Tests.Attributes
{
    /// <summary>
    /// Tests for the Values attribute which provides parameter values for test methods.
    /// Similar to NUnit's [Values] attribute for parameterized tests.
    /// </summary>
    public class ValuesAttributeTests
    {
        /// <summary>
        /// Test with integer values.
        /// </summary>
        [Test]
        [Group(nameof(ValuesAttribute))]
        public void ValuesAttributeTest_IntegerValues([Values(1, 2, 3, 4, 5)] int value)
        {
            Assert.IsTrue(value >= 1 && value <= 5);
            Trace.WriteLine($"Testing with value: {value}");
        }

        /// <summary>
        /// Test with string values.
        /// </summary>
        [Test]
        [Group(nameof(ValuesAttribute))]
        public void ValuesAttributeTest_StringValues([Values("Alpha", "Beta", "Gamma")] string value)
        {
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Length > 0);
            Trace.WriteLine($"Testing with value: {value}");
        }

        /// <summary>
        /// Test with boolean values.
        /// </summary>
        [Test]
        [Group(nameof(ValuesAttribute))]
        public void ValuesAttributeTest_BooleanValues([Values(true, false)] bool value)
        {
            Trace.WriteLine($"Testing with boolean value: {value}");
        }

        /// <summary>
        /// Test with multiple parameters each having values.
        /// </summary>
        [Test]
        [Group(nameof(ValuesAttribute))]
        public void ValuesAttributeTest_MultipleParameters(
            [Values(1, 2)] int x,
            [Values("A", "B")] string s)
        {
            Assert.IsTrue(x > 0);
            Assert.IsNotNull(s);
            Trace.WriteLine($"Testing with x={x}, s={s}");
        }
    }
}
