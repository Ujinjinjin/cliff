using System.CommandLine;

namespace Cliff.Factories;

public interface IOptionFactory
{
	/// <summary> Create command option </summary>
	/// <param name="aliases">List of option's aliases</param>
	/// <param name="description">Option description</param>
	/// <param name="isRequired">Defines if option is required or not</param>
	Option<T> CreateOption<T>(string[] aliases, string description, bool isRequired);
}
