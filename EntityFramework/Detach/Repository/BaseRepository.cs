using AuditEntry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Detach.Repository
{
    public class BaseRepository<T> where T : class
    {
        private readonly AuditDbContext _databaseContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository()
        {
            _databaseContext = new AuditDbContext();
            _dbSet = _databaseContext.Set<T>();
        }

        public IQueryable<T> CustomQueryNT()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> CustomQuery()
        {
            return _dbSet;
        }

        public async Task Add(T entity)
        {
           await _dbSet.AddAsync(entity); 
           await _databaseContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _databaseContext.Update(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _databaseContext.SaveChangesAsync();
        }


        public async Task Remove(T entity)
        {
             _dbSet.Remove(entity);
             await _databaseContext.SaveChangesAsync();
        }

        public void Detach(T entity) 
        {

            if (entity == null)
                return;

            _databaseContext.Entry(entity).State = EntityState.Detached;
        }
    }
}
