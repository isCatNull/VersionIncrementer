namespace VersionIncrementer.Application;

public interface IVersionReader
{
    Task<string> ReadAsync();
}
