using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Severino.Common.Domain;

namespace Severino.Common.Repository.EF
{
    /// <summary>
    /// Classe base para os repositorios baseados em Entity Framework
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade manipulada repositorio</typeparam>
    /// <typeparam name="TContext">Contexto de conexao com o banco de dados</typeparam>
    public abstract class BaseRepositoryEF<TEntity, TContext> : IBaseRepository<TEntity> 
        where TEntity : BaseModel
        where TContext : DbContext
    {
        private bool _disposed;

        /// <summary>
        /// Contexto de conexão com o banco de dados
        /// </summary>
        protected TContext Context { get; }

        /// <summary>
        /// Metodo construtor
        /// </summary>
        /// <param name="context">Contexto de conexao com o banco de dados</param>
        public BaseRepositoryEF(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        /// <summary>
        /// Adiciona uma nova entidade de maneira assincrona
        /// </summary>
        /// <param name="item">Entidade a ser adicionada</param>
        /// <returns>Retorna a entidade que foi adicionada no contexto</returns>
        /// <exception cref="T:System.ArgumentNullException">Ocorre quando o parametro 'item' nao for informado</exception>
        public virtual async Task<TEntity> AddAsync(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await Context.AddAsync(item);
            return item;
        }

        /// <inheritdoc />
        /// <summary>
        /// Atualiza uma entidade no contexto de forma assincrona 
        /// </summary>
        /// <param name="item">Entidade a ser atualizada</param>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException">Ocorre quando o parametro 'item' nao for informado</exception>
        public virtual Task UpdateAsync(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return Task.Run(() => { Context.Update(item); });
        }

        /// <inheritdoc />
        /// <summary>
        /// Remove uma entidade do contexto de forma assincrona
        /// </summary>
        /// <param name="item">Entidade que sera removida</param>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException">Ocorre quando o parametro 'item' nao for informado</exception>
        public virtual Task RemoveAsync(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return Task.Run(() => { Context.Remove(item); });
        }

        /// <inheritdoc />
        /// <summary>
        /// Consulta uma entidade pelo codigo de identificacao
        /// </summary>
        /// <param name="id">Codigo utilizado para realizar a consulta</param>
        /// <param name="expand">Indica se devem ser retornadas as entidades filhas</param>
        /// <returns></returns>
        public virtual Task<TEntity> GetByIdAsync(Guid id, bool expand)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            if (expand)
                query = ExpandQuery(query);

            return query.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Metodo responsavel por expandir a query para retornar as entidades filhas
        /// </summary>
        /// <param name="query">Query original que sera expandida</param>
        /// <returns>Retorna a query expandida</returns>
        protected abstract IQueryable<TEntity> ExpandQuery(IQueryable<TEntity> query);

        /// <summary>
        /// Libera os recursos utilizados
        /// </summary>
        /// <param name="disposing">Indica se devem ser liberados os recursos gerenciados</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Context.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// Libera os recursos utilizados
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}