using Microsoft.AspNetCore.Identity;

namespace Schoolmate.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string GivenNames { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string FamilyName { get; set; } = String.Empty;
    public DateOnly Birthday { get; set; }
    public char Gender { get; set; }
}
