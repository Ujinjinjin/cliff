using Cliff;
using Cliff.Factories;
using Cliff.Template.Services;
using System.CommandLine;

namespace Cliff.Template.Controllers;

public class WeatherController : CliController
{
	private readonly IWeatherService _weatherService;

	public WeatherController(
		RootCommand rootCommand,
		ICommandFactory commandFactory,
		IOptionFactory optionFactory,
		IWeatherService weatherService
	) : base(
		rootCommand,
		commandFactory,
		optionFactory
	)
	{
		_weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
	}

	public override void Register()
	{
		Register(GetDisplayCommand());
	}

	private Command GetDisplayCommand()
	{
		var temperature = OptionFactory.CreateOption<int>(new[] { "--temperature", "-t" }, "Temperature in celsius", true);

		var command = CommandFactory.CreateCommand(
			"display",
			"Display current weather",
			temperature
		);

		command.SetHandler(o => _weatherService.DisplayWeatherConditionMessage(o), temperature);

		return command;
	}
}
