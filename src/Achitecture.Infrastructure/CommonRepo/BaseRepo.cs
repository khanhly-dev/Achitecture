using Achitecture.Domain.Common;
using Achitecture.Repository.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Infrastructure.Persistence.EntityFrameworkCore.CommonRepo
{
    public class BaseRepo<TEntity, TKey> : DapperRepo<TEntity, TKey>, IBaseRepo<TEntity, TKey>
        where TEntity : BaseAuditableEntity<TKey>
    {
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }
        /// <summary>
        /// soft delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remove(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            entity.IsDeleted = true;
        }

        /// <summary>
        /// hard delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// get instace of dbcontext
        /// </summary>
        /// <returns></returns>
        public DbSet<TEntity> GetDbSet()
        {
            return _dbSet;
        }

        /// <summary>
        /// add created time when create entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Create(TEntity entity)
        {
            entity.CreatedTime = DateTime.Now;
            _dbSet.Add(entity);
        }

        /// <summary>
        /// create log when save change
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task SaveChangeAsync(string user = "")
        {
            var entities = _dbContext.ChangeTracker.Entries<BaseAuditableEntity<TKey>>();
            foreach (var entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = user;
                    entry.Entity.CreatedTime = DateTime.Now;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy = user;
                    entry.Entity.LastModifiedTime = DateTime.Now;
                }
            }

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all record not be deleted by condition
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            var listEntity = await _dbSet
                .Where(x => x.IsDeleted == false)
                .Where(expression)
                .ToListAsync();
            return listEntity;
        }

        /// <summary>
        /// Get all record not be deleted
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAll()
        {
            var listEntity = await _dbSet
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
            return listEntity;
        }

        /// <summary>
        /// Get all by condition
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllIncludeDeleted(Expression<Func<TEntity, bool>> expression)
        {
            var listEntity = await _dbSet
                .Where(expression)
                .ToListAsync();
            return listEntity;
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllIncludeDeleted()
        {
            var listEntity = await _dbSet
                .ToListAsync();
            return listEntity;
        }

        /// <summary>
        /// Get one record not be deleted by condition
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _dbSet
                .Where(x => x.IsDeleted == false)
                .FirstOrDefaultAsync(expression);
            return entity;
        }

        /// <summary>
        /// Get one record by condition
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<TEntity> GetIncludeDeleted(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _dbSet
                .FirstOrDefaultAsync(expression);
            return entity;
        }
    }
}
