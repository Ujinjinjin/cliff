namespace Cliff.Infrastructure;

/// <summary> Cli service </summary>
public interface ICliService
{
	/// <summary> Execute command from CLI </summary>
	/// <param name="args">Arguments passed to application</param>
	Task<int> ExecuteAsync(string[] args);
}