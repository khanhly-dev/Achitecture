using AutoMapper;
using AutoMapper.QueryableExtensions;
using Achitecture.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Achitecture.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        /// <summary>
        /// Convert IQueryable to paginated list after mapper
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        {
            return queryable.PagingAsync(pageNumber, pageSize);
        }

        /// <summary>
        /// Convert IQueryable to list after mapper
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
        {
            return queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
        }    
    }
}
