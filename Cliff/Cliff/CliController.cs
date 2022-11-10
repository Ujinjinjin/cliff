using System.CommandLine;
using Cliff.Factories;

namespace Cliff;

/// <summary> Base CLI controller </summary>
public abstract class CliController : IController
{
	protected readonly RootCommand RootCommand;
	protected readonly ICommandFactory CommandFactory;
	protected readonly IOptionFactory OptionFactory;

	protected CliController(RootCommand rootCommand, ICommandFactory commandFactory, IOptionFactory optionFactory)
	{
		RootCommand = rootCommand ?? throw new ArgumentNullException(nameof(rootCommand));
		CommandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
		OptionFactory = optionFactory ?? throw new ArgumentNullException(nameof(optionFactory));
	}

	/// <inheritdoc />
	public abstract void Register();
}