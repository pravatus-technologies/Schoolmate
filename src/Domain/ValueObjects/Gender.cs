using Ardalis.SmartEnum;

namespace Schoolmate.Domain.ValueObjects;

public sealed class Gender : SmartEnum<Gender>
{
    public static readonly Gender Male = new Gender(nameof(Male), 1);
    public static readonly Gender Female = new Gender(nameof(Female), 2);

    private Gender(string name, int value) : base(name, value)
    {
    }
}
