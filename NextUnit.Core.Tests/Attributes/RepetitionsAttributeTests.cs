using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class RepetitionsAttributeTests
    {        /// <summary>
             /// This has to repeat the Test n times [Repetitions(n)]
             /// </summary>
        [Test]
        [Repetitions(7)]
        public void RepetitionsTest()
        {

        }
    }
}
