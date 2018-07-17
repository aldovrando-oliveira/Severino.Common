using System;
using System.Threading.Tasks;
using Severino.Common.Domain;
using Severino.Common.Exceptions;
using Severino.Common.Repository;
using Severino.Common.Util;

namespace Severino.Common.Business
{
    /// <summary>
    /// Classe que implementa o contrato da interface <see cref="IBaseBusiness{TRepository,TEntity}"/>
    /// </summary>
    /// <typeparam name="TRepository">Tipo do repositório que deve ser utilizado pela classe</typeparam>
    /// <typeparam name="TEntity">Tipo da entidade que será manipulado pela classe de negócio</typeparam>
    public class BaseBusiness<TRepository, TEntity> : IBaseBusiness<TRepository, TEntity>
        where TEntity : BaseModel
        where TRepository : IBaseRepository<TEntity>
    {
        /// <summary>
        /// Repositório utilizado para acesso ao contexto do banco de dados
        /// </summary>
        protected virtual TRepository Repository { get; }

        /// <summary>
        /// Metodo construtor
        /// </summary>
        /// <param name="repository">Repositorio base utilizado pela classe de negocio</param>
        /// <exception cref="ArgumentNullException">Ocorre quando o parametro 'repository' nao for informado</exception>
        public BaseBusiness(TRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            Repository = repository;
        }

        /// <inheritdoc />
        public virtual Task<TEntity> AddAsync(TEntity model)
        {
            return Repository.AddAsync(model);
        }

        /// <inheritdoc />
        /// <exception cref="T:System.ArgumentException">Ocorre quando o parametro 'id' for invalido</exception>
        public virtual async Task<TEntity> GetById(Guid id, bool expand)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Parâmetro '{0}' inválido", nameof(id));

            var model = await Repository.GetByIdAsync(id, expand);
            return model;
        }

        /// <inheritdoc />
        /// <exception cref="T:System.ArgumentException">Ocorre quando o parametro 'id' for invalido</exception>
        /// <exception cref="T:Severino.Common.Exceptions.EntityNotFoundException">Ocorre quando a entidade nao for encontrada</exception>
        public virtual async Task RemoveAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Parâmetro '{0}' inválido", nameof(id));

            var model = await Repository.GetByIdAsync(id, false);

            if (model == null)
                throw new EntityNotFoundException(typeof(TEntity));

            await Repository.RemoveAsync(model);
        }

        /// <inheritdoc />
        public virtual Task RemoveAsync(TEntity model)
        {
            return Repository.RemoveAsync(model);
        }

        /// <inheritdoc />
        /// <exception cref="T:System.ArgumentException">Ocorre quando o parametro 'id' for invalido</exception>
        /// <exception cref="T:Severino.Common.Exceptions.EntityNotFoundException">Ocorre quando a entidade nao for encontrada</exception>
        public virtual async Task UpdateAsync(Guid id, TEntity model)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Parâmetro '{0}' inválido", nameof(id));

            var dbModel = await Repository.GetByIdAsync(id, false);

            if (dbModel == null)
                throw new EntityNotFoundException(typeof(TEntity));

            model.CopyPropertiesTo(dbModel);
        }

        #region IDisposable Support

        private bool _disposed = false;

        /// <summary>
        /// Libera recursos utilizados
        /// </summary>
        /// <param name="disposing">Indica se devem ser liberados os recursos gerenciados</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Repository.Dispose();
            }

            _disposed = true;
        }

        /// <inheritdoc />
        /// <summary>
        /// Libera recursos utilizados
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}