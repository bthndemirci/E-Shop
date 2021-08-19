using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Core.Exceptions;
using EShop.Core.Signatures;
using EShop.DataAccess.Contexts.EF;
using Microsoft.EntityFrameworkCore;

namespace EShop.DataAccess.Repositories.EF
{
    public class EfRepository<TEntity> :IRepository<TEntity>
        where TEntity:class,IBaseEntity,new()
    {
        private readonly EShopContext _context;
        private readonly DbSet<TEntity> _entities;
        public EfRepository(EShopContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Table => _entities;

        public IQueryable<TEntity> AsNoTracking => _entities.AsNoTracking();

        public async Task<bool> AnyAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity != null;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
           
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _entities.FirstOrDefaultAsync(filter);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new DbNullException(typeof(TEntity).Name);

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.CreatedUser = "";
            entity.UpdatedUser = "";
            
            await _entities.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new DbNullException(typeof(TEntity).Name);
            
            var oldEntity = await GetAsync(entity.Id);
            if (oldEntity == null)
                throw new DbNullException("Old " + typeof(TEntity).Name);
            
            entity.CreatedAt = oldEntity.CreatedAt;
            entity.CreatedUser = oldEntity.CreatedUser;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedUser = "";
            
            _context.Update(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null) throw new DbNullException(typeof(TEntity).Name);
            _entities.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<TEntity> entities)
        {
            if (!entities.Any())
                throw new DbNullException(typeof(TEntity).Name);

            foreach (var entity in entities)
            {
                //_context.Entry(entity).State = EntityState.Detached;
                _entities.Remove(entity);
            }
            await SaveChangesAsync();
        }
        
        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                _context.ChangeTracker.Entries().ToList().ForEach(x => { x.State = EntityState.Detached; });
            }
            catch (DbUpdateException e)
            {
                throw new DbException(GetFullError(e));
            }
            catch (Exception e)
            {
                throw new DbException(GetFullError(e));
            }
        }

        private string GetFullError(Exception e)
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => { x.State = EntityState.Detached; });
            return e.ToString();
        }
    }
}