using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schoolmate.Application.Common.Interfaces;
using Schoolmate.Domain.Constants;
using Schoolmate.Infrastructure.Data.Contexts;
using Schoolmate.Infrastructure.Data.Interceptors;
using Schoolmate.Infrastructure.Identity;

namespace Schoolmate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddAdmissionInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("SM_ADMIS") ?? string.Empty;

        Guard.Against.NullOrEmpty(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<AdmissionDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IAdmissionDbContext>(provider => provider.GetRequiredService<AdmissionDbContext>());

        services.AddScoped<AdmissionDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true; // no duplicate users
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

#if DEBUG
                options.SignIn.RequireConfirmedAccount = false;
#else
                options.SignIn.RequireConfirmedAccount = true;
#endif
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AdmissionDbContext>();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        return services;
    }
}
