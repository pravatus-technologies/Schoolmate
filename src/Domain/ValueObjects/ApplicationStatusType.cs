using Ardalis.SmartEnum;

namespace Schoolmate.Domain.ValueObjects;

public class ApplicationStatusType : SmartEnum<ApplicationStatusType>
{
    public static readonly ApplicationStatusType Opened = new ApplicationStatusType(nameof(Opened), 1);
    public static readonly ApplicationStatusType Submitted = new ApplicationStatusType(nameof(Submitted), 2);
    public static readonly ApplicationStatusType Reviewing = new ApplicationStatusType(nameof(Reviewing), 3);

    public static readonly ApplicationStatusType
        PendingApproval = new ApplicationStatusType(nameof(PendingApproval), 4);

    public static readonly ApplicationStatusType OnHold = new ApplicationStatusType(nameof(OnHold), 5);
    public static readonly ApplicationStatusType Approved = new ApplicationStatusType(nameof(Approved), 6);
    public static readonly ApplicationStatusType Rejected = new ApplicationStatusType(nameof(Rejected), 7);
    public static readonly ApplicationStatusType Withdrawn = new ApplicationStatusType(nameof(Withdrawn), 8);
    
    private ApplicationStatusType(string name, int value) : base(name, value)
    {
    }
}
