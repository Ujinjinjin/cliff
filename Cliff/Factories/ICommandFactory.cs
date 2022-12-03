using System.CommandLine;

namespace Cliff.Factories;

public interface ICommandFactory
{
    /// <summary> Create CLI command </summary>
    /// <param name="name">Command name</param>
    /// <param name="description">Command description</param>
    /// <param name="options">List of options</param>
    Command CreateCommand(string name, string description, params Option[] options);

    /// <summary> Create CLI command </summary>
    /// <param name="name">Command name</param>
    /// <param name="description">Command description</param>
    /// <param name="isHidden">Indicates whether the symbol is hidden</param>
    /// <param name="options">List of options</param>
    Command CreateCommand(string name, string description, bool isHidden = false, params Option[] options);
}
