﻿using Microsoft.EntityFrameworkCore;
using PB201MovieApp.Core.Entities;
using System.Linq.Expressions;

namespace PB201MovieApp.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table { get; }
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        //public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>>? expression = null, bool asNoTracking = false, params string[] includes);
        //Task<TEntity> GetByIdAsync(int id);
        Task<int> CommitAsync();
    }
}
