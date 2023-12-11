using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Schoolmate.Infrastructure.Data.Contexts;

public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
{
    public AuthDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>();
        optionsBuilder
            .UseSqlServer(Environment.GetEnvironmentVariable("SM_AUTH"),
                builderOptions =>
                    builderOptions.MigrationsAssembly(typeof(AuthDbContext).GetTypeInfo().Assembly.GetName().Name));

        return new AuthDbContext(optionsBuilder.Options);
    }
}
