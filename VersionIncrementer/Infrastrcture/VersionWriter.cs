using VersionIncrementer.Application;

namespace VersionIncrementer.Infrastrcture;

public class VersionWriter : IVersionWriter
{
    public async Task WriteAsync(string versionNumber)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(),
            "..\\..\\..\\..\\Data\\ProductInfo.cs");

        await using var streamWriter = new StreamWriter(path);

        await streamWriter.WriteAsync(versionNumber);
    }
}
