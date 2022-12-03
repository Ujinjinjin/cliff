using System.CommandLine;

namespace Cliff.Factories;

public class CommandFactory : ICommandFactory
{
	/// <inheritdoc />
	public Command CreateCommand(string name, string description, params Option[] options)
	{
		return CreateCommand(name, description, Visibility.Visible, options);
	}

	/// <inheritdoc />
	public Command CreateCommand(string name, string description, Visibility visibility, params Option[] options)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentException("Name must be provided");
		}

		if (string.IsNullOrWhiteSpace(description))
		{
			throw new ArgumentException("Description must be provided");
		}

		var command = new Command(name, description) { IsHidden = visibility == Visibility.Hidden };

		for (var i = 0; i < options.Length; i++)
		{
			command.AddOption(options[i]);
		}

		return command;
	}
}
