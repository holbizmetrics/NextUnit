using NextUnit.Core.TestAttributes;
using System.Reflection;

namespace AutoFixture.NextUnit.Tests;

public class BlubAttribute : CustomizeAttribute
{
	public override ICustomization GetCustomization(ParameterInfo parameter)
	{
		throw new NotImplementedException();
	}
}
public class CustomizeAttributeTests
{
	[Test]
	public void CustomizeAttributeTest([Blub] int n1)
	{

	}
}
