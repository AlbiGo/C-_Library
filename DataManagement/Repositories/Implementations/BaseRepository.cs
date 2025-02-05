using DataManagement.DbContext;
using DataManagement.Entities;
using DataManagement.Repositories.Interfaces;
using System.Data.Entity;

namespace DataManagement.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _databaseContext;
        private readonly Microsoft.EntityFrameworkCore.DbSet<T> _dbSet;

        public BaseRepository()
        {
            _databaseContext = new DatabaseContext();
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

        public async Task SoftRemoveRelated(T entity)
        {
            entity.Updated = DateTime.Now;
            entity.Deleted = DateTime.Now;
            _dbSet.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            var foreignKeys = _databaseContext.Model.FindEntityType(typeof(T))
                .GetNavigations();

            foreach (var fk in foreignKeys)
            {
                var relatedRecord = _dbSet.Entry(entity)
              .Reference(fk).TargetEntry;

                await relatedRecord.ReloadAsync();

                relatedRecord.CurrentValues.SetValues(new Dictionary<string, object> { { "Updated", DateTime.UtcNow }, { "Deleted", DateTime.Now } });

                relatedRecord.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _databaseContext.Update(relatedRecord.Entity);
            }

            await _databaseContext.SaveChangesAsync();
        }

        public async Task SoftRemoveRelated(T entity, string[] relatedEntities = null)
        {
            entity.Updated = DateTime.Now;
            entity.Deleted = DateTime.Now;
            _dbSet.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            var checkEntity = _databaseContext.Model.FindEntityType(typeof(T));

            if (checkEntity == null)
            {
                throw new Exception("Entity not found");
            }
            var foreignKeys = checkEntity.GetNavigations();

            if (foreignKeys.Any())
            {
                foreach (var fk in foreignKeys)
                {
                    if (relatedEntities.Contains(fk.Name))
                    {
                        var relatedEntityType = fk.ClrType.Name;

                        if (relatedEntityType.Contains("List") || relatedEntityType.Contains("Array"))
                        {
                            var collections = _dbSet.Entry(entity)
                                .Collections;

                            if (collections.Any())
                            {
                                foreach (var internalCollectionValue in collections.Select(p => p.CurrentValue))
                                {
                                    if (internalCollectionValue != null)
                                    {
                                        foreach (var value in internalCollectionValue)
                                        {
                                            var rlEntity = ((BaseEntity)value);
                                            rlEntity.Updated = DateTime.Now;
                                            rlEntity.Deleted = DateTime.Now;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            var relatedRecord = _dbSet.Entry(entity)
                                .Reference(fk).TargetEntry;

                            if (relatedRecord != null)
                            {
                                await relatedRecord.ReloadAsync();

                                relatedRecord.CurrentValues.SetValues(new Dictionary<string, object> { { "Updated", DateTime.UtcNow }, { "Deleted", DateTime.Now } });
                                relatedRecord.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                                _databaseContext.Update(relatedRecord.Entity);
                            }
                        }
                    }
                }
            }

            await _databaseContext.SaveChangesAsync();
        }

        public async Task SoftRemove(T entity)
        {
            entity.Updated = DateTime.Now;
            entity.Deleted = DateTime.Now;
            _dbSet.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            await _databaseContext.SaveChangesAsync();
        }

        public void Detach(T entity)
        {
            if (entity == null)
                return;

            _databaseContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
    }
}