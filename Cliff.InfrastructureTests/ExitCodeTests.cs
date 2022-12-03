using Cliff.Test.Helpers;
using Cliff.Test.Infrastructure;
using Xunit;

namespace Cliff.Test;

public class ExitCodeTests
{
	[Fact]
	public async Task ExitCodeTests_WhenValidArgumentsGiven_ThenAppFinishesWithSuccessCode()
	{
		// arrange
		var args = Arguments.Success.Valid;
		var testProgram = new TestCliProgram(args);

		// act
		var exitCode = await testProgram.ExecuteAsync();

		// assert
		Assert.Equal(ExitCode.Success, exitCode);
	}

	[Fact]
	public async Task ExitCodeTests_WhenRequiredArgumentNotGiven_ThenAppFinishesWithErrorCode()
	{
		// arrange
		var args = Arguments.Success.Invalid;
		var testProgram = new TestCliProgram(args);

		// act
		var exitCode = await testProgram.ExecuteAsync();

		// assert
		Assert.Equal(ExitCode.Error, exitCode);
	}

	[Fact]
	public async Task ExitCodeTests_WhenCommandThrowsException_ThenAppFinishesWithErrorCode()
	{
		// arrange
		var args = Arguments.Fail.Default;
		var testProgram = new TestCliProgram(args);

		// act
		var exitCode = await testProgram.ExecuteAsync();

		// assert
		Assert.Equal(ExitCode.Error, exitCode);
	}
}
