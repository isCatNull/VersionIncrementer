using VersionIncrementer.Application.Validators;
using VersionIncrementer.Domain;
using Xunit;

namespace VersionIncrementer.Tests.Application.Tests.Validators.Tests;

public class InputValidatorTests
{
    [Theory]
    [InlineData(ReleaseType.Feature)]
    [InlineData(ReleaseType.BugFix)]
    public void Validate_CorrectInput_DoesNotThrow(string releaseType)
    {
        // Arrange
        var inputValidor = new InputValidator();
        
        // Act & Assert
        Assert.Null(
            Record.Exception(() => inputValidor.Validate(releaseType)));
    }

    [Theory]
    [InlineData("")]
    [InlineData("Uknown type")]
    public void Validate_IncorrectInput_ThrowsException(string releaseType)
    {
        // Arrange
        var inputValidor = new InputValidator();

        // Act
        Assert.Throws<ArgumentException>(
            () => inputValidor.Validate(releaseType));
    }
}
