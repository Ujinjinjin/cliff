using System.CommandLine;

namespace Cliff.Factories;

public class OptionFactory : IOptionFactory
{
    /// <inheritdoc />
    public Option<T> CreateOption<T>(string[] aliases, string description, bool isRequired)
    {
        if (aliases is null || aliases.Length == 0)
        {
            throw new ArgumentException("At least 1 alias must be provided", nameof(aliases));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description must be provided", nameof(description));
        }

        return new Option<T>(aliases, description) { IsRequired = isRequired, };
    }
}