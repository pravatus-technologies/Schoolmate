namespace Schoolmate.Domain.Entities.ApplicantAggregate;

public class AcademicHistory : BaseEntity
{
    public int ApplicantId { get; set; }

    public string ProgramName { get; set; } = string.Empty;

    public string Institution { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
    
    public string? TelephoneNum { get; set; }
    
    public string? LastAcademicYearAttended { get; set; }

    public bool IsCompleted { get; set; } = false;
}
