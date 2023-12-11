namespace Schoolmate.Domain.Entities.ApplicantAggregate;

public class ApplicationStatus : BaseAuditableEntity
{
    public int ApplicantId { get; private set; }
    public ApplicationStatusType ApplicationStatusType { get; private set; } = ApplicationStatusType.Opened;
}
