using System.CommandLine;
using Cliff.Factories;

namespace Cliff;

/// <summary> Base CLI controller </summary>
public abstract class CliController : IController
{
	private readonly RootCommand _rootCommand;
	protected readonly ICommandFactory CommandFactory;
	protected readonly IOptionFactory OptionFactory;

	protected CliController(RootCommand rootCommand, ICommandFactory commandFactory, IOptionFactory optionFactory)
	{
		_rootCommand = rootCommand ?? throw new ArgumentNullException(nameof(rootCommand));
		CommandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
		OptionFactory = optionFactory ?? throw new ArgumentNullException(nameof(optionFactory));
	}

	protected void Register(Command command)
	{
		_rootCommand.Add(command);
	}

	/// <inheritdoc />
	public abstract void Register();
}