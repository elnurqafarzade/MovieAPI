using Microsoft.EntityFrameworkCore;
using PB201MovieApp.Core.Entities;
using PB201MovieApp.Core.Repositories;
using PB201MovieApp.DAL.Contexts;
using System.Linq.Expressions;


namespace PB201MovieApp.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDBContext _context;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(TEntity entity)

           => Table.Remove(entity);

        //public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
        //{
        //    var query = Table.AsQueryable();

        //    if (includes.Length > 0)
        //    {
        //        foreach (var include in includes)

        //            query = query.Include(include);


        //        query = asNoTracking == true
        //            ? query.AsNoTracking()
        //            : query;

        //        return expression is null
        //            ? query.AsNoTracking().Where(expression)
        //            : query;
        //    }
    }

        //public async Task<TEntity> GetByIdAsync(int id)
        //{
        //    await Table.FindAsync(id);
        //}
}

