using Cliff.Infrastructure;
using Cliff.Playground.Controllers;
using Cliff.Playground.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cliff.Playground.Infrastructure;

/// <inheritdoc />
public class TestIocModule : BaseIocModule
{
	public TestIocModule(string appName, string appDesc)
		: base(appName, appDesc)
	{
	}

	protected override void RegisterServices(IServiceCollection collection)
	{
		// Register services
		collection.AddSingleton<ITestService, TestService>();

		// Register controllers
		collection.AddSingleton<IController, TestController>();
	}
}
