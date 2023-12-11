using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Schoolmate.Infrastructure.Data.Contexts;

public class AdmissionDbContextFactory : IDesignTimeDbContextFactory<AdmissionDbContext>
{
    public AdmissionDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AdmissionDbContext>();
        optionsBuilder
            .UseSqlServer(Environment.GetEnvironmentVariable("SM_ADMIS"),
                builderOptions =>
                    builderOptions.MigrationsAssembly(typeof(AdmissionDbContext).GetTypeInfo().Assembly.GetName().Name));

        return new AdmissionDbContext(optionsBuilder.Options);
    }
}
