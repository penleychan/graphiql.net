using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Core.Data;

namespace StarWars.Data.EntityFramework.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>, new()
    {
        protected DbContext Db;

        protected BaseRepository() { }

        protected BaseRepository(DbContext db)
        {
            Db = db;
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return Db.Set<TEntity>().ToListAsync();
        }

        public Task<List<TEntity>> GetAll(string include)
        {
            return Db.Set<TEntity>().Include(include).ToListAsync();
        }

        public Task<List<TEntity>> GetAll(IEnumerable<string> includes)
        {
            var query = Db.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToListAsync();
        }

        public virtual Task<TEntity> Get(TKey id)
        {
            return Db.Set<TEntity>().SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, string include)
        {
            return Db.Set<TEntity>().Include(include).SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, IEnumerable<string> includes)
        {
            var query = Db.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public virtual TEntity Add(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Db.Set<TEntity>().AddRange(entities);
        }

        public virtual void Delete(TKey id)
        {
            var entity = new TEntity { Id = id };
            Db.Set<TEntity>().Attach(entity);
            Db.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            Db.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return (await Db.SaveChangesAsync()) > 0;
        }
    }
}