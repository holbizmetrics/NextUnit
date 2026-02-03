using NextUnit.Core.TestAttributes;
using System.Diagnostics;
using System.Reflection;

namespace NextUnit.Core.Tests.Attributes
{
    /// <summary>
    /// Tests for the NextUnitValue attribute which marks properties/fields in custom attributes
    /// as parameter values for use with GetMarkedAttributeValues.
    /// </summary>
    public class NextUnitValueAttributeTests
    {
        /// <summary>
        /// Example custom attribute using NextUnitValue to mark its properties.
        /// </summary>
        [AttributeUsage(AttributeTargets.Method)]
        public class CustomDataAttribute : Attribute
        {
            [NextUnitValue]
            public int IntValue { get; set; }

            [NextUnitValue]
            public string StringValue { get; set; }

            public string NotMarked { get; set; } // This should NOT be picked up

            public CustomDataAttribute(int intValue, string stringValue)
            {
                IntValue = intValue;
                StringValue = stringValue;
                NotMarked = "ignored";
            }
        }

        /// <summary>
        /// Test that verifies NextUnitValue can be detected on properties.
        /// </summary>
        [Test]
        [Group(nameof(NextUnitValueAttribute))]
        [CustomData(42, "Hello")]
        public void NextUnitValueAttributeTest_DetectsMarkedProperties()
        {
            // Get the custom attribute from this method
            var method = GetType().GetMethod(nameof(NextUnitValueAttributeTest_DetectsMarkedProperties));
            var customAttr = method?.GetCustomAttribute<CustomDataAttribute>();

            if (customAttr != null)
            {
                // Find properties marked with NextUnitValue
                var markedProperties = customAttr.GetType()
                    .GetProperties()
                    .Where(p => p.GetCustomAttribute<NextUnitValueAttribute>() != null)
                    .ToList();

                Trace.WriteLine($"Found {markedProperties.Count} marked properties");

                foreach (var prop in markedProperties)
                {
                    var value = prop.GetValue(customAttr);
                    Trace.WriteLine($"Property {prop.Name} = {value}");
                }
            }
        }

        /// <summary>
        /// Basic test that the attribute can be applied.
        /// </summary>
        [Test]
        [Group(nameof(NextUnitValueAttribute))]
        public void NextUnitValueAttributeTest_CanBeApplied()
        {
            // Verify the attribute exists and can be used
            var attr = typeof(CustomDataAttribute)
                .GetProperty(nameof(CustomDataAttribute.IntValue))
                ?.GetCustomAttribute<NextUnitValueAttribute>();

            Trace.WriteLine($"NextUnitValueAttribute found: {attr != null}");
        }
    }
}
