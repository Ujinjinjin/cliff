using System.CommandLine;

namespace Cliff.Factories;

public class OptionFactory : IOptionFactory
{
    /// <inheritdoc />
    public Option<T> CreateOption<T>(string[] aliases, string description, bool required)
    {
        return new Option<T>(aliases, description) { IsRequired = required, };
    }
}