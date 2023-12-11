using Ardalis.SmartEnum;

namespace Schoolmate.Domain.ValueObjects;

public class CivilStatus : SmartEnum<CivilStatus>
{
    public static readonly CivilStatus Single = new CivilStatus(nameof(Single), 1);
    public static readonly CivilStatus Married = new CivilStatus(nameof(Married), 2);
    public static readonly CivilStatus Separated = new CivilStatus(nameof(Separated), 3);
    public static readonly CivilStatus Widowed = new CivilStatus(nameof(Widowed), 4);
    
    public CivilStatus(string name, int value) : base(name, value)
    {
    }
}
