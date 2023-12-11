namespace Schoolmate.Domain.Entities.ApplicantAggregate;

public class HealthInformation
{
    public int ApplicantId { get; set; }
    
    public string? MedicalConditions { get; set; }
    
    public string? KnownAllergies { get; set; }
    
    public BloodType? BloodType { get; set; }
    
    public string? PhysiciansName { get; set; }
}
