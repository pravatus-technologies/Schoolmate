using Ardalis.SmartEnum;

namespace Schoolmate.Domain.ValueObjects;

public class BloodType : SmartEnum<BloodType>
{
    public static readonly BloodType O = new BloodType(nameof(O), 1);
    public static readonly BloodType OPos = new BloodType(nameof(OPos), 2);
    public static readonly BloodType ONeg = new BloodType(nameof(ONeg), 3);
    public static readonly BloodType B = new BloodType(nameof(B), 4);
    public static readonly BloodType BPos = new BloodType(nameof(BPos), 5);
    public static readonly BloodType BNeg = new BloodType(nameof(BNeg), 6);
    public static readonly BloodType A = new BloodType(nameof(A), 7);
    public static readonly BloodType APos = new BloodType(nameof(APos), 8);
    public static readonly BloodType ANeg = new BloodType(nameof(ANeg), 9);
    public static readonly BloodType AB = new BloodType(nameof(AB), 10);
    public static readonly BloodType ABPos = new BloodType(nameof(ABPos), 11);
    public static readonly BloodType ABNeg = new BloodType(nameof(ABNeg), 12);
    
    public BloodType(string name, int value) : base(name, value)
    {
    }
}
