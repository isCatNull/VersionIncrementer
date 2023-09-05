using System.Text;

namespace VersionIncrementer.Application.Services;

public class IncrementerService : IIncrementerService
{
    public string UpdateMinorVersion(string version)
    {
        var versionArray = version.Split('.');
        var minorVersion = versionArray[3];
        var updatedNumericVersion = int.Parse(minorVersion) + 1;

        var stringBuilder = new StringBuilder();

        for (int i = 0; i < 3; i++)
        {
            stringBuilder.Append(versionArray[i]);
            stringBuilder.Append('.');
        }

        stringBuilder.Append(updatedNumericVersion);

        return stringBuilder.ToString();
    }

    public string UpdateMajorVersion(string version)
    {
        var versionArray = version.Split('.');

        var majorVersion = versionArray[2];

        var numericMajorVersion = int.Parse(majorVersion) + 1;

        var stringBuilder = new StringBuilder();

        for (int i = 0; i < 2; i++)
        {
            stringBuilder.Append(versionArray[i]);
            stringBuilder.Append('.');
        }
        stringBuilder.Append(numericMajorVersion);
        stringBuilder.Append(".0");

        return stringBuilder.ToString();
    }
}
