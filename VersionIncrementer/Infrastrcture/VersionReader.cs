using VersionIncrementer.Application;

namespace VersionIncrementer.Infrastrcture;

public class VersionReader : IVersionReader
{
    public async Task<string> ReadAsync()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(),
            "..\\..\\..\\..\\Data\\ProductInfo.cs");

        using var streamReader = new StreamReader(path);

        var version = await streamReader.ReadLineAsync()
            ?? throw new InvalidDataException("File contains no contents");

        return version;
    }
}
