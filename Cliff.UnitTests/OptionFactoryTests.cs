using Cliff.Factories;
using Cliff.UnitTests.Helpers;

namespace Cliff.UnitTests;

public class OptionFactoryTests
{
    [Fact]
    public void OptionFactoryTests_WhenValidParametersGiven_ThenOptionCreatedWithExactParameters()
    {
        // arrange
        var optionFactory = new OptionFactory();
        var optionParameters = OptionHelper.GetOptionParameters();

        // act
        var option = optionFactory.CreateOption<int>(
            optionParameters.Aliases,
            optionParameters.Description,
            optionParameters.IsRequired
        );

        // assert
        Assert.NotNull(option);
        Assert.Equal(optionParameters.Aliases.Length, option.Aliases.Count);
        Assert.Equal(optionParameters.Description, option.Description);
        Assert.Equal(optionParameters.IsRequired, option.IsRequired);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(new object[] { new string[0] })]
    public void OptionFactoryTests_WhenAliasesNotProvided_ThenExceptionThrown(string[] aliases)
    {
        // arrange
        var optionFactory = new OptionFactory();
        var optionParameters = OptionHelper.GetOptionParameters();

        // act & act
        Assert.Throws<ArgumentException>(
            () => optionFactory.CreateOption<int>(
                aliases,
                optionParameters.Description,
                optionParameters.IsRequired
            )
        );
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void OptionFactoryTests_WhenDescriptionNotProvided_ThenExceptionThrown(string description)
    {
        // arrange
        var optionFactory = new OptionFactory();
        var optionParameters = OptionHelper.GetOptionParameters();

        // act & act
        Assert.Throws<ArgumentException>(
            () => optionFactory.CreateOption<int>(
                optionParameters.Aliases,
                description,
                optionParameters.IsRequired
            )
        );
    }
}