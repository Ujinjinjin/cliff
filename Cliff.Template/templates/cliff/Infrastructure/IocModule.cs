using Cliff;
using Cliff.Infrastructure;
using Cliff.Template.Controllers;
using Cliff.Template.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cliff.Template.Infrastructure;

public class IocModule : BaseIocModule
{
	public IocModule(string appName, string appDesc)
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
