using System.CommandLine;
using Cliff.Factories;
using Cliff.UnitTests.Models;

namespace Cliff.UnitTests.Helpers;

public static class OptionHelper
{
    public static Option[] GetOptions(int? count = default)
    {
        var optionFactory = new OptionFactory();
        if (count == default)
        {
            var rnd = new Random();
            count = rnd.Next(1, 20);
        }

        var options = new Option[count.Value];
        for (var i = 0; i < count; i++)
        {
            options[i] = GetOption<int>(optionFactory);
        }

        return options;
    }

    public static Option<T> GetOption<T>(
        IOptionFactory? optionFactory = null
    )
    {
        optionFactory ??= new OptionFactory();
        var optionParameter = GetOptionParameters();

        return optionFactory.CreateOption<T>(
            optionParameter.Aliases,
            optionParameter.Description,
            optionParameter.IsRequired
        );
    }
    
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

    public static string[] GetAliases(int? count = default)
    {
        if (count == default)
        {
            var rnd = new Random();
            count = rnd.Next(1, 20);
        }

        var aliases = new string[count.Value];
        for (var i = 0; i < count; i++)
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