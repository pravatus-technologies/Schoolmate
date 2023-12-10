using Schoolmate.Domain.Entities;

namespace Schoolmate.Application.Common.Interfaces;

public interface IAuthDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
