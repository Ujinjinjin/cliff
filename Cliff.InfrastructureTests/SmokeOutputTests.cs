using Cliff.Test.Helpers;
using Cliff.Test.Infrastructure;
using Xunit;

namespace Cliff.Test;

public class SmokeOutputTests
{
	[Fact]
	public async Task SmokeOutputTests_WhenValidArgumentsGiven_ThenAppExecutesSuccessfully()
	{
		// arrange
		using var consoleOutput = new ConsoleOutput();
		var args = Arguments.Success.Valid;
		var testProgram = new TestCliProgram(args);

		// act
		await testProgram.ExecuteAsync();

		// assert
		Assert.Equal(args[^1], consoleOutput.Get());
	}

	[Fact]
	public async Task SmokeOutputTests_WhenRequiredArgumentNotGiven_ThenCommandNotExecuted()
	{
		// arrange
		using var consoleOutput = new ConsoleOutput();
		var args = Arguments.Success.Invalid;
		var testProgram = new TestCliProgram(args);

		// act
		await testProgram.ExecuteAsync();

		// assert
		Assert.NotEqual(args[^1], consoleOutput.Get());
	}
}
