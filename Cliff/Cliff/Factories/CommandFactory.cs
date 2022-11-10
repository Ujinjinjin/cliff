using System.CommandLine;

namespace Cliff.Factories;

public class CommandFactory : ICommandFactory
{
    /// <inheritdoc />
    public Command CreateCommand(string name, string description, params Option[] options)
    {
        var command = new Command(name, description);

        for (var i = 0; i < options.Length; i++)
        {
            command.AddOption(options[i]);
        }

        return command;
    }
}