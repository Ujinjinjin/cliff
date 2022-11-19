using Cliff.UnitTests.Models;

namespace Cliff.UnitTests.Helpers;

public static class OptionHelper
{
    public static OptionParameters GetOptionParameters(
        string[]? aliases = null,
        string? description = null,
        bool? isRequired = null
    )
    {
        aliases ??= GetAliases();
        description ??= GetDescription();
        isRequired ??= GetRequired();

        return new OptionParameters
        {
            Aliases = aliases,
            Description = description,
            IsRequired = isRequired.Value,
        };
    }

    public static string[] GetAliases(int? aliasesCount = default)
    {
        if (aliasesCount == default)
        {
            var rnd = new Random();
            aliasesCount = rnd.Next(1, 20);
        }

        var aliases = new string[aliasesCount.Value];

        for (var i = 0; i < aliasesCount; i++)
        {
            aliases[i] = Guid.NewGuid().ToString();
        }

        return aliases;
    }

    public static string GetDescription()
    {
        return Guid.NewGuid().ToString();
    }

    public static bool GetRequired()
    {
        var rnd = new Random();
        return rnd.Next() % 2 == 0;
    }
}