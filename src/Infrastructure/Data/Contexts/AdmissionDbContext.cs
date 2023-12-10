using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schoolmate.Application.Common.Interfaces;
using Schoolmate.Domain.Entities;
using Schoolmate.Infrastructure.Identity;

namespace Schoolmate.Infrastructure.Data.Contexts;

public class AdmissionDbContext : IdentityDbContext<ApplicationUser>, IAdmissionDbContext
{
    public AdmissionDbContext(DbContextOptions<AdmissionDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
