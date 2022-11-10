using Cliff.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.CommandLine;
using Cliff.ConsoleUtils;

namespace Cliff.Infrastructure;

/// <inheritdoc />
public sealed class CliService : ICliService
{
	/// <inheritdoc />
	public IServiceProvider ServiceProvider { get; }

	private readonly ILogger _logger;
	private readonly IConsoleQueue _consoleQueue;

	public CliService(IServiceProvider serviceProvider, IConsoleQueue consoleQueue)
	{
		ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
		_consoleQueue = consoleQueue ?? throw new ArgumentNullException(nameof(consoleQueue));

		_logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger<CliService>() ?? throw new ArgumentNullException(nameof(ILoggerFactory));
	}

	/// <inheritdoc />
	public async Task ExecuteAsync(string[] args)
	{
		try
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
		catch (Exception ex)
		{
			_logger.LogError(ex, $"Error occured during command execution with args: {args}");
			await _consoleQueue.EnqueueOutputAsync("Error! Please try again or contact the maintainer of this solution");
		}
	}
}