using System.CommandLine;
using Cliff.UnitTests.Models;

namespace Cliff.UnitTests.Helpers;

public static class CommandHelper
{
    public static CommandParameters GetCommandParameters(
        string? name = null,
        string? description = null,
        Option[]? options = null
    )
    {
        name ??= GetName();
        description ??= GetDescription();
        options ??= OptionHelper.GetOptions();
        
        return new CommandParameters
        {
            Name = name,
            Description = description,
            Options = options,
        };
    }

    public static string GetName()
    {
        return Guid.NewGuid().ToString();
    }

    public static string GetDescription()
    {
        return Guid.NewGuid().ToString();
    }
}