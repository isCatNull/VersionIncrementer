namespace VersionIncrementer.Application;

public interface IVersionWriter
{
    Task WriteAsync(string versionNumber);
}
