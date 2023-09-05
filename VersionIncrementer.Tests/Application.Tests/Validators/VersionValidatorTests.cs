using VersionIncrementer.Application.Validators;
using Xunit;

namespace VersionIncrementer.Tests.Application.Tests.Validators.Tests;

public class VersionValidorTests
{
    [Theory]
    [InlineData("")]
    [InlineData("0.1.z.3")]
    [InlineData("0.1.")]
    [InlineData("0.3.44")]
    [InlineData("1.3.43.0.6")]
    public void Validate_InvalidData_DoesThrow(string version)
    {
        // Arrange
        var versionValidor = new VersionValidator();

        // Act
        Assert.Throws<ArgumentException>(
            () => versionValidor.Validate(version));
    }

    [Theory]
    [InlineData("1.3.43.0")]
    [InlineData("0.0.0.0")]
    [InlineData("100.03.33.0")]
    [InlineData("13.3.43.34")]
    public void Validate_ValidData_DoesNotThrow(string version)
    {
        // Arrange
        var versionValidor = new VersionValidator();

        // Act & Assert
        Assert.Null(
            Record.Exception(() => versionValidor.Validate(version)));
    }
}
