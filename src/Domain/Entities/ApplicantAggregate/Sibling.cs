namespace Schoolmate.Domain.Entities.ApplicantAggregate;

public class Sibling : BaseEntity
{
   public int ApplicantId { get; set; }

   public string Name { get; set; } = string.Empty;
   
   public int? Age { get; set; }
   
   public string? School { get; set; }

   public string? EducationalLevel { get; set; }
}
