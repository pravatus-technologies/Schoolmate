using Schoolmate.Domain.Entities.ApplicantAggregate;

namespace Schoolmate.Application.Common.Interfaces;

public interface IAdmissionDbContext
{
    DbSet<Applicant> Applicants { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
