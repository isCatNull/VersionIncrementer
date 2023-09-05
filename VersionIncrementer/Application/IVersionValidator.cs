namespace VersionIncrementer.Application;

public interface IVersionValidator
{
    void Validate(string version);
}