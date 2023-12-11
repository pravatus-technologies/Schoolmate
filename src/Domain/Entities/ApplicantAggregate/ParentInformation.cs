using Ardalis.GuardClauses;

namespace Schoolmate.Domain.Entities.ApplicantAggregate;

public class ParentInformation : BaseEntity
{
#pragma warning disable CS8618
    public int ApplicantId { get; private set; }
    public string GivenNames { get; private set; }
    public string? MiddleName { get; private set; }
    public string FamilyName { get; private set; }
    public ParentType ParentType { get; private set; }
    public string? HomeTelephone { get; private set; } 
    public string? MobileTelephone { get; private set; }
    public string? EmailAddress { get; private set; }
    public string? Occupation { get; private set; }
    public string? EmployerName { get; private set; }
    public string? HighestEducationAttainment { get; private set; }
    public string? SchoolAttended { get; private set; }
    public bool IsDeceased { get; private set; } = false;
#pragma warning restore CS8618

#pragma warning disable CS8618
    private ParentInformation()
#pragma warning restore CS8618
    {
    }

    public static ParentInformation Create()
    {
        return new ParentInformation();
    }
}
