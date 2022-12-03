using Cliff.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Cliff.Test.Infrastructure;

public class TestCliProgram
{
	private readonly string[] _args;

	public TestCliProgram(string[] args)
	{
		_args = args;
	}

	public async Task<int> ExecuteAsync()
	{
		IServiceProvider serviceProvider = new TestIocModule("test", "Test cli application")
			.Build();

		var cliService = serviceProvider.GetService<ICliService>();

		if (cliService is null)
		{
			Console.WriteLine("Warning! CLI Service was not found");
			return -1;
		}

		return await cliService.ExecuteAsync(_args);
	}
}
