using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Persistence
{
    public interface IApplicationDbContext
    {
        //DbSet<MyEnity> MyEntity { get; set; }
        DbSet<TodoList> TodoLists { get; }

        DbSet<TodoItem> TodoItems { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<int> SaveToDbAsync();
    }
}
