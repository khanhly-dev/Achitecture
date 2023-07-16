using Dapper;
using Achitecture.Domain.Common;
using Achitecture.Repository.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Infrastructure.Persistence.EntityFrameworkCore.CommonRepo
{
    public class DapperRepo<TEntity, TKey> : IDapperRepo<TEntity, TKey> 
        where TEntity : BaseAuditableEntity<TKey>
    {
        protected readonly ApplicationDbContext _dbContext;
        protected DapperRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// excute query output entity
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> ExcuteQuery(string sql, object param)
        {
            IDbConnection db = _dbContext.Database.GetDbConnection();
            return (await db.QueryAsync<TEntity>(sql, param)).ToList<TEntity>();
        }

        /// <summary>
        /// excute query output custom model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<TModel>> ExcuteQuery<TModel>(string sql, object param)
        {
            IDbConnection db = _dbContext.Database.GetDbConnection();
            return (await db.QueryAsync<TModel>(sql, param)).ToList<TModel>();
        }

        /// <summary>
        /// excute non query as delete, update, insert . . .
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<int> ExcuteNonQuery(string sql, object param)
        {
            IDbConnection db = _dbContext.Database.GetDbConnection();
            var result = await db.ExecuteAsync(sql, param);
            return result;
        }
    }
}
