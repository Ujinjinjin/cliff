using System.CommandLine;
using Cliff.Factories;
using Cliff.Playground.Services;

namespace Cliff.Playground.Controllers;

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
        Register(GetSuccessfulCommand());
        Register(GetFailingCommand());
        Register(GetHiddenCommand());
    }

    private Command GetSuccessfulCommand()
    {
        var option = OptionFactory.CreateOption<string>(new[] { "--output", "-o" }, "Output value", true);

        var command = CommandFactory.CreateCommand(
            "success",
            "Successful command",
            option
        );

        command.SetHandler(o => _testService.SuccessfulAction(o), option);

        return command;
    }

    private Command GetFailingCommand()
    {
        var option = OptionFactory.CreateOption<string>(new[] { "--output", "-o" }, "Output value", true);

        var command = CommandFactory.CreateCommand(
            "fail",
            "Failing command",
            option
        );

        command.SetHandler(o => _testService.FailingAction(o), option);

        return command;
    }

    private Command GetHiddenCommand()
    {
        var option = OptionFactory.CreateOption<string>(new[] { "--output", "-o" }, "Output value", true);

        var command = CommandFactory.CreateCommand(
            "hidden",
            "Hidden command",
            true,
            option
        );

        command.SetHandler(o => _testService.HiddenAction(o), option);

        return command;
    }
}
