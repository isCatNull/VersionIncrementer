namespace VersionIncrementer.Application.Validators;

public class VersionValidator : IVersionValidator
{
    public void Validate(string version)
    {
        var numberOfDots = version.Count(x => x == '.');

        if(numberOfDots != 3)
        {
            throw new ArgumentException($"Invalid format of the version: {version}");
        }

        var versionNumber = version.Replace(".", "");
        
        if(!versionNumber.All(char.IsDigit))
        {
            throw new ArgumentException($"Invalid format of the version: {version}");
        }
    }
}
