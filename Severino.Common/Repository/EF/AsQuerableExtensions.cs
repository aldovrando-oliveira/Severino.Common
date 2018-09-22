using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Severino.Common.Paging;

namespace Severino.Common.Repository.EF
{
    /// <summary>
    /// Helpers para consulta paginadas
    /// </summary>
    public static class AsQuerableExtensions
    {
        
        /// <summary>
        /// Realiza a consulta paginada
        /// </summary>
        /// <param name="query">Objeto do tipo <see cref="IQueryable{T}"/> com a consulta base para a paginaçao</param>
        /// <param name="pageConfig">Configuraçao da paginaçao</param>
        /// <typeparam name="T">Tipo do objeto da consulta</typeparam>
        /// <returns>Retorna um objeto do tipo <see cref="ListPaged{T}"/></returns>
        /// <exception cref="ArgumentNullException">Ocorre quando o parametro "query" ou "pageConfig" nao sao informados</exception>
        public static ListPaged<T> ToListPaged<T>(this IQueryable<T> query, PageRequest pageConfig)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            
            if (pageConfig == null)
                throw new ArgumentNullException(nameof(pageConfig));
            
            if (pageConfig.Page < 1) 
                pageConfig.Page = 1;

            if (!string.IsNullOrEmpty(pageConfig.SortProperty))
            {
                var orderBy = $"{pageConfig.SortProperty}{(pageConfig.SortDirection.HasValue ? " " : "")}{(pageConfig.SortDirection == SortDirection.Ascending ? "ASC" : "DESC")}";
                query = query.OrderBy(orderBy);
            }

            var recordCount = query.Count();
            var totalPages = recordCount < pageConfig.PageSize ? 1 : recordCount / pageConfig.PageSize;
            
            if (recordCount > (totalPages * pageConfig.PageSize)) 
                totalPages++;

            var pageResponse = new PageResponse
            {
                Page = new PageResponse.PageInfo
                {
                    Current = pageConfig.Page,
                    Total = totalPages,
                    Size = pageConfig.PageSize
                },
                RecordCount = recordCount
            };

            query = query.Skip(pageConfig.PageSize * (pageConfig.Page - 1)).Take(pageConfig.PageSize);

            var queryResult = query.ToList();
            var result = new ListPaged<T>();
            result.AddRange(queryResult);
            result.Page = pageResponse;

            return result;
        }

        /// <summary>
        /// Realiza a consulta paginada de forma assincrona
        /// </summary>
        /// <param name="query">Objeto do tipo <see cref="IQueryable{T}"/> com a consulta base para a paginaçao</param>
        /// <param name="pageConfig">Configuraçao da paginaçao</param>
        /// <typeparam name="T">Tipo do objeto da consulta</typeparam>
        /// <returns>Retorna um objeto do tipo <see>
        ///         <cref>Task{ListPaged{T}}</cref>
        ///     </see>
        /// </returns>
        /// <exception cref="ArgumentNullException">Ocorre quando o parametro "query" ou "pageConfig" nao sao informados</exception>
        public static async Task<ListPaged<T>> ToListPagedAsync<T>(this IQueryable<T> query, PageRequest pageConfig)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            
            if (pageConfig == null)
                throw new ArgumentNullException(nameof(pageConfig));

            if (pageConfig.Page < 1) pageConfig.Page = 1;

            if (!string.IsNullOrEmpty(pageConfig.SortProperty))
            {
                var orderBy = $"{pageConfig.SortProperty}{(pageConfig.SortDirection.HasValue ? " " : "")}{(pageConfig.SortDirection == SortDirection.Ascending ? "ASC" : "DESC")}";
                query = query.OrderBy(orderBy);
            }

            var recordCount = await query.CountAsync();
            var totalPages = recordCount < pageConfig.PageSize ? 1 : recordCount / pageConfig.PageSize;
            
            if (recordCount > (totalPages * pageConfig.PageSize)) 
                totalPages++;

            var pageResponse = new PageResponse
            {
                Page = new PageResponse.PageInfo
                {
                    Current = pageConfig.Page,
                    Total = totalPages,
                    Size = pageConfig.PageSize
                },
                RecordCount = recordCount
            };

            query = query.Skip(pageConfig.PageSize * (pageConfig.Page - 1)).Take(pageConfig.PageSize);

            var queryResult = await query.ToListAsync();
            var result = new ListPaged<T>();
            result.AddRange(queryResult);
            result.Page = pageResponse;

            return result;
        }
        
        private static IQueryable<T> OrderBy<T>(this IQueryable<T> q, string sortField)
        {
            var dados = sortField.Split(' ');

            var orderby = dados.Length == 1 ? "ASC" : dados[1];

            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, dados[0]);
            var exp = Expression.Lambda(prop, param);
            var method = orderby == "ASC" ? "OrderBy" : "OrderByDescending";
            var types = new[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }

    }
}