using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Schoolmate.Application.Common.Interfaces;
using Schoolmate.Domain.Entities.ApplicantAggregate;

namespace Schoolmate.Infrastructure.Data.Contexts;

public class AdmissionDbContext : DbContext, IAdmissionDbContext
{
    public DbSet<Applicant> Applicants => Set<Applicant>();
    public AdmissionDbContext(DbContextOptions<AdmissionDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), p => p.Namespace is "Schoolmate.Infrastructure.Data.Configurations.Admissions");

        base.OnModelCreating(builder);
    }
}
