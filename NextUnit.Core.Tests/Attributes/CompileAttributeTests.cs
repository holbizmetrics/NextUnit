using NextUnit.Core.TestAttributes;
using static NextUnit.Core.AttributeLogic.LogicHandlers.CompileAttributeLogicHandler;
using System.Reflection;

namespace NextUnit.Core.Tests.Attributes
{
    public class CompileAttributeTests
    {
        public const string source =
@"
using System;
namespace DynamicNamespace
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}";
        [Test]
        [Group(nameof(CompileAttribute))]
        [Compile(source: source, useFile: false, methodName: "DynamicMethod")]
        public void TestCompiledCode()
        {
            var compiledObject = CompiledObjectRegistry.Retrieve(MethodBase.GetCurrentMethod().Name);
            var methodInfo = compiledObject.GetType().GetMethod("Add");
            var result = methodInfo.Invoke(compiledObject, new object[] { 1, 2 });

            // Assert on the `result` as needed
        }
    }
}
