using VersionIncrementer.Domain;

namespace VersionIncrementer.Application.Validators;

public class InputValidator : IInputValidator
{
    public void Validate(string input)
    {
        switch(input)
        {
            case ReleaseType.BugFix:
            case ReleaseType.Feature:
                break;
            default:
                throw new ArgumentException($"Provided {input} release type is invalid");
        }
    }
}
