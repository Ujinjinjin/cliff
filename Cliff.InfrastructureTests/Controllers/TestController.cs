using System.CommandLine;
using Cliff.Factories;
using Cliff.Test.Services;

namespace Cliff.Test.Controllers;

public class TestController : CliController
{
	private readonly ITestService _testService;

	public TestController(
		RootCommand rootCommand,
		ICommandFactory commandFactory,
		IOptionFactory optionFactory,
		ITestService testService
	) : base(
		rootCommand,
		commandFactory,
		optionFactory
	)
	{
		_testService = testService ?? throw new ArgumentNullException(nameof(testService));
	}

	public override void Register()
	{
		RegisterSuccessfulCommand();
		RegisterFailingCommand();
	}

	private void RegisterSuccessfulCommand()
	{
		var option = OptionFactory.CreateOption<string>(new[] { "--output", "-o" }, "Output value", true);

		var command = CommandFactory.CreateCommand(
			"success",
			"Successful command",
			option
		);

		command.SetHandler(o => _testService.SuccessfulAction(o), option);

		Register(command);
	}

	private void RegisterFailingCommand()
	{
		var option = OptionFactory.CreateOption<string>(new[] { "--output", "-o" }, "Output value", true);

		var command = CommandFactory.CreateCommand(
			"fail",
			"Failing command",
			option
		);

		command.SetHandler(o => _testService.FailingAction(o), option);

		Register(command);
	}
}
