using Achitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Repository.Common.Interface
{
    public interface IDapperRepo<TEntity, TKey>
        where TEntity : BaseAuditableEntity<TKey>
    {
        /// <summary>
        /// excute query output entity
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<List<TEntity>> ExcuteQuery(string sql, object param);

        /// <summary>
        /// excute query output custom model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<List<TModel>> ExcuteQuery<TModel>(string sql, object param);

        /// <summary>
        /// excute non query as delete, update, insert . . .
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<int> ExcuteNonQuery(string sql, object param);
    }
}
