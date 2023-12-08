using CleanArchitecture.Application.Persistence;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public DbSet<TodoList> TodoLists => throw new NotImplementedException();

        public DbSet<TodoItem> TodoItems => throw new NotImplementedException();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveToDbAsync()
        {
            throw new NotImplementedException();
        }
    }
}
