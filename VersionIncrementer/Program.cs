using Microsoft.Extensions.DependencyInjection;
using VersionIncrementer.Application;
using VersionIncrementer.Application.Services;
using VersionIncrementer.Application.Validators;
using VersionIncrementer.Domain;
using VersionIncrementer.Infrastrcture;

var services = new ServiceCollection();

services.AddTransient<IInputValidator, InputValidator>();
services.AddTransient<IVersionReader, VersionReader>();
services.AddTransient<IVersionValidator, VersionValidator>();
services.AddTransient<IIncrementerService, IncrementerService>();
services.AddTransient<IVersionWriter, VersionWriter>();

await using var serviceProvider = services.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

var inputValidator = scope.ServiceProvider.GetRequiredService<IInputValidator>();
var versionReader = scope.ServiceProvider.GetRequiredService<IVersionReader>();
var versionValidator = scope.ServiceProvider.GetRequiredService<IVersionValidator>();
var versionIncrementor = scope.ServiceProvider.GetRequiredService<IIncrementerService>();
var versionWriter = scope.ServiceProvider.GetRequiredService<IVersionWriter>();

try
{
    var releaseType = args[0];
    inputValidator.Validate(releaseType);

    var versionNumber = await versionReader.ReadAsync();

    versionValidator.Validate(versionNumber);

    string updatedVersion;

    if (releaseType.Equals(ReleaseType.BugFix))
    {
        updatedVersion = versionIncrementor.UpdateMinorVersion(versionNumber);
    }
    else if (releaseType.Equals(ReleaseType.Feature))
    {
        updatedVersion = versionIncrementor.UpdateMajorVersion(versionNumber);
    }
    else
    {
        Console.Error.WriteLine("Unsupported release type");
        return;
    }

    await versionWriter.WriteAsync(updatedVersion);
}
catch(Exception ex)
{
    Console.Error.WriteLine($"Something went wrong: {ex.Message}");
}
