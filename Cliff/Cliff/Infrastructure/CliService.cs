using System.CommandLine;
using Cliff.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cliff.Infrastructure;

/// <inheritdoc />
public sealed class CliService : ICliService
{
	/// <inheritdoc />
	public IServiceProvider ServiceProvider { get; }

	private readonly ILogger _logger;

	public CliService(IServiceProvider serviceProvider)
	{
		ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
		_logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger<CliService>() ?? throw new ArgumentNullException(nameof(ILoggerFactory));
	}

	/// <inheritdoc />
	public async Task ExecuteAsync(string[] args)
	{
		try
		{
			await TryExecuteAsync(args);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, $"Error occured during command execution with args: {args}");
		}
	}

	private async Task TryExecuteAsync(string[] args)
	{
		ServiceProvider.RegisterControllers();

		var root = ServiceProvider.GetService<RootCommand>();

		if (root is null)
		{
			throw new ApplicationException("Root command was not found");
		}

		await root.InvokeAsync(args);
	}
}
