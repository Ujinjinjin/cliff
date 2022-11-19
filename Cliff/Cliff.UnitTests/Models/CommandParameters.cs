using System.CommandLine;

namespace Cliff.UnitTests.Models;

public class CommandParameters
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Option[] Options { get; set; }
}