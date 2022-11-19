using Cliff.Factories;
using Cliff.UnitTests.Helpers;

namespace Cliff.UnitTests;

public class CommandFactoryTests
{
    [Fact]
    public void CommandFactoryTests_WhenValidParametersGiven_ThenCommandCreatedWithExactParameters()
    {
        // arrange
        var commandFactory = new CommandFactory();
        var commandParameters = CommandHelper.GetCommandParameters();

        // act
        var command = commandFactory.CreateCommand(
            commandParameters.Name,
            commandParameters.Description,
            commandParameters.Options
        );

        // assert
        Assert.NotNull(command);
        Assert.Equal(commandParameters.Name, command.Name);
        Assert.Equal(commandParameters.Description, command.Description);
        Assert.Equal(commandParameters.Options.Length, command.Options.Count);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void CommandFactoryTests_WhenNameNotProvided_ThenExceptionThrown(string name)
    {
        // arrange
        var commandFactory = new CommandFactory();
        var commandParameters = CommandHelper.GetCommandParameters();

        // act & assert
        Assert.Throws<ArgumentException>(
            () => commandFactory.CreateCommand(
                name,
                commandParameters.Description,
                commandParameters.Options
            )
        );
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void CommandFactoryTests_WhenDescriptionNotProvided_ThenExceptionThrown(string description)
    {
        // arrange
        var commandFactory = new CommandFactory();
        var commandParameters = CommandHelper.GetCommandParameters();

        // act & assert
        Assert.Throws<ArgumentException>(
            () => commandFactory.CreateCommand(
                commandParameters.Name,
                description,
                commandParameters.Options
            )
        );
    }
}