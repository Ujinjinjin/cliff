using System.CommandLine;
using Cliff.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cliff.Infrastructure;

/// <inheritdoc />
public abstract class BaseIocModule : IIocModule
{
	private readonly string _appName;
	private readonly string _appDesc;

	protected BaseIocModule(string appName, string appDesc)
	{
		_appName = appName ?? throw new ArgumentNullException(nameof(appName));
		_appDesc = appDesc ?? throw new ArgumentNullException(nameof(appDesc));
	}

	/// <inheritdoc />
	public IServiceProvider Build()
	{
		var collection = new ServiceCollection();

		var rootCommand = new RootCommand
		{
			Name = _appName,
			Description = _appDesc,
		};
		collection.AddSingleton(rootCommand);

		collection.UseCliff();

		RegisterServices(collection);

		return collection.BuildServiceProvider();
	}

	protected abstract void RegisterServices(IServiceCollection collection);
}
