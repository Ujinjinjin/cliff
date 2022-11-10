using System.CommandLine;
using Cliff.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cliff.Infrastructure;

/// <inheritdoc />
public sealed class CliService : ICliService
{
	/// <inheritdoc />
	public IServiceProvider ServiceProvider { get; }

	public CliService(IServiceProvider serviceProvider)
	{
		ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
	}

	/// <inheritdoc />
	public async Task ExecuteAsync(string[] args)
	{
		var rootCommand = ServiceProvider
			.RegisterControllers()
			.GetService<RootCommand>();

		if (rootCommand is null)
		{
			throw new Exception($"Couldn't find any registered {nameof(RootCommand)}");
		}

		await rootCommand.InvokeAsync(args);
	}
}