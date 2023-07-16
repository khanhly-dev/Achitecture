using Achitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Repository.Common.Interface
{
    public interface IBaseRepo<TEntity, TKey> : IDapperRepo<TEntity, TKey>
        where TEntity : BaseAuditableEntity<TKey>
    {
        /// <summary>
        /// get instace of dbcontext
        /// </summary>
        /// <returns></returns>
        DbSet<TEntity> GetDbSet();

        /// <summary>
        /// soft delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Remove(TKey id);

        /// <summary>
        /// hard delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(TKey id);

        /// <summary>
        /// add created time when create entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Create(TEntity entity);

        /// <summary>
        /// create log when save change
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task SaveChangeAsync(string user = "");

        /// <summary>
        /// Get all record not be deleted by condition
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Get all record not be deleted
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAll();

        /// <summary>
        /// Get all by condition
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllIncludeDeleted(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllIncludeDeleted();

        /// <summary>
        /// Get one record not be deleted by condition
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Get one record by condition
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<TEntity> GetIncludeDeleted(Expression<Func<TEntity, bool>> expression);
    }
}
