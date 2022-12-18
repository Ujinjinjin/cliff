using Cliff.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

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
		collection.AddSingleton<IWeatherService, WeatherService>();

		// Register controllers
		collection.AddSingleton<IController, WeatherController>();
	}
}
