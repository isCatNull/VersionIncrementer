namespace VersionIncrementer.Application;

public interface IIncrementerService
{
    string UpdateMinorVersion(string version);

    string UpdateMajorVersion(string version);

}
