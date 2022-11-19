using System.CommandLine;
using Cliff.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cliff.Infrastructure;

/// <inheritdoc />
public sealed class CliService : ICliService
{
	private readonly IServiceProvider _serviceProvider;

	private readonly ILogger _logger;

	public CliService(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
		_logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger<CliService>() ?? throw new ArgumentNullException(nameof(ILoggerFactory));
	}

	/// <inheritdoc />
	public async Task<int> ExecuteAsync(string[] args)
	{
		var exitCode = await TryExecuteAsync(args);
		if (exitCode > 0)
		{
			_logger.LogError($"Error occured during command execution with args: {string.Join(", ", args)}");
		}

		return exitCode;
	}

	private async Task<int> TryExecuteAsync(string[] args)
	{
		_serviceProvider.RegisterControllers();

		var root = _serviceProvider.GetService<RootCommand>();

		if (root is null)
		{
			throw new ApplicationException("Root command was not found");
		}

		return await root.InvokeAsync(args);
	}
}
