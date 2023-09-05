using VersionIncrementer.Application.Services;
using Xunit;

namespace VersionIncrementer.Tests.Application.Tests.Services;

public class VersionIncrementerTests
{
    [Theory]
    [InlineData("1.0.1.3", "1.0.1.4")]
    [InlineData("1.0.1.100", "1.0.1.101")]
    [InlineData("1.0.1.32", "1.0.1.33")]
    [InlineData("1.0.1.0", "1.0.1.1")]
    [InlineData("1.0.1.00", "1.0.1.1")]
    public void UpdateMinorVersion_IncrementsMinorVersion(string version, string expectedVersion)
    {
        // Arrange
        var versionIncrementer = new IncrementerService();

        // Act
        var versionResult = versionIncrementer.UpdateMinorVersion(version);

        // Assert
        Assert.True(versionResult.Equals(expectedVersion));
    }

    [Theory]
    [InlineData("1.0.1.3", "1.0.2.0")]
    [InlineData("1.0.1.100", "1.0.2.0")]
    [InlineData("1.0.1.32", "1.0.2.0")]
    [InlineData("1.0.56.0", "1.0.57.0")]
    [InlineData("1.0.0.00", "1.0.1.0")]
    [InlineData("1.0.10.0", "1.0.11.0")]
    public void UpdateMajorVersion_IncrementsMajorVersion(string version, string expectedVersion)
    {
        // Arrange
        var versionIncrementer = new IncrementerService();

        // Act
        var versionResult = versionIncrementer.UpdateMajorVersion(version);

        // Assert
        Assert.True(versionResult.Equals(expectedVersion));
    }
}
