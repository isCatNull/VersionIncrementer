using System.Text;

namespace VersionIncrementer.Application.Services;

public class IncrementerService : IIncrementerService
{
    public string UpdateMinorVersion(string version)
    {
        var versionCharacters = version.Split('.');
        var minorVersion = versionCharacters[3];
        var incrementedVersion = int.Parse(minorVersion) + 1;

        var stringBuilder = new StringBuilder();

        for (int i = 0; i < 3; i++)
        {
            stringBuilder.Append(versionCharacters[i]);
            stringBuilder.Append('.');
        }

        stringBuilder.Append(incrementedVersion);

        return stringBuilder.ToString();
    }

    public string UpdateMajorVersion(string version)
    {
        var versionCharacters = version.Split('.');
        var majorVersion = versionCharacters[2];
        var incrementedVersion = int.Parse(majorVersion) + 1;

        var stringBuilder = new StringBuilder();

        for (int i = 0; i < 2; i++)
        {
            stringBuilder.Append(versionCharacters[i]);
            stringBuilder.Append('.');
        }
        stringBuilder.Append(incrementedVersion);
        stringBuilder.Append(".0");

        return stringBuilder.ToString();
    }
}
