using NextUnit.Core.Accessors;
using NextUnit.Core.Asserts;
using NextUnit.Core.TestAttributes;
using System.Diagnostics;
using System.Reflection;

namespace NextUnit.Core.Tests.Attributes
{
    public class CommonTestAttributeTests
    {
        [Test]
        public void CommonTestAttributeTest()
        {
            IEnumerable<Attribute> attributes = new StackFrame().GetMethod().GetCustomAttributes();
            Attribute attribute = attributes.FirstOrDefault();
            bool isDefaultAttribute = attribute.IsDefaultAttribute();
            Assert.IsFalse(isDefaultAttribute);
            AccessWrapper accessWrapper = new AccessWrapper(attribute.TypeId);
            var baseType = accessWrapper.AsDynamic().BaseType;
            Assert.IsNotNull(baseType);
            Assert.IsOfType<CommonTestAttribute>(baseType);
        }
    }
}
