using NextUnit.Core.Asserts;
using NextUnit.Core.TestAttributes;

namespace NextUnit.Core.Tests.Attributes
{
    public class DependencyInjectionAttributeTests
    {
        public interface IMyService
        {
            string GetData();
        }

        public class MyServiceImplementation : IMyService
        {
            public string GetData()
            {
                return "Sample Data";
            }
        }

        [Test, DependencyInjection(typeof(IMyService))]
        [Group(nameof(DependencyInjectionAttribute))]
        public void MyTestMethod(IMyService service)
        {
            // Assert that the service is successfully injected
            Assert.IsNotNull(service);

            // Use the service in your test
            var data = service.GetData();
            Assert.AreEqual("Sample Data", data);

            // Additional test logic...
        }
    }
}
