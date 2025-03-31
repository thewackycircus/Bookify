﻿using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Repository
{
    internal abstract class Repository<T> where T : Entity
    {
        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<T>()
                .FirstOrDefaultAsync(Entity => Entity.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            DbContext.Add(entity);
        }
    }
}
