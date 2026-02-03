using NextUnit.Core.TestAttributes;
using NextUnit.TestRunner.Attributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class CustomExtendableAttributeTests
    {        /// <summary>
             /// This provides extendable attributes to extend the framework.
             /// Specifics have not been implemented, yet. But for example could already be used to write
             /// messages to console, debug, etc.
             /// </summary>
        [Test]
        [ConsoleCustomExtendable]
        [Group(nameof(CustomExtendableAttribute))]
        public void CustomExtendableAttributeTest()
        {
            //Writes a text to the console for now.
            //How? The text is specified in the console.
        }
    }
}
