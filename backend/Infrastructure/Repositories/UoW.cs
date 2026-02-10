using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Interfaces.Repositories;
using backend.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.Infrastructure.Repositories
{
    public class UoW : IUoW
    {
        private readonly RollDBContext _context;
        public IDbContextTransaction? Transaction { get; private set; }

        public UoW(RollDBContext context)
        {
            _context = context;
        }

        public async Task Begin()
        {
            Transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (Transaction != null)
                await Transaction.CommitAsync();
        }

        public async Task Dispose()
        {
            if (Transaction != null)
                await Transaction.DisposeAsync();
        }

        public async Task Rollback()
        {
            if (Transaction != null)
            {
                await Transaction.RollbackAsync();
                await Transaction.DisposeAsync();
            }
        }
    }
}