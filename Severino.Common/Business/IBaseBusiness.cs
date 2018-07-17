using System;
using System.Threading.Tasks;
using Severino.Common.Domain;
using Severino.Common.Repository;

namespace Severino.Common.Business
{
    /// <summary>
    /// Contrato para a classes base de regras de negócio
    /// </summary>
    /// <typeparam name="TRepository">Tipo do repositório que deve ser utilizado pela classe</typeparam>
    /// <typeparam name="TEntity">Tipo da entidade que será manipulado pela classe de negócio</typeparam>
    public interface IBaseBusiness<TRepository, TEntity> : IDisposable
        where TRepository : IBaseRepository<TEntity>
        where TEntity: BaseModel
    {
        /// <summary>
        /// Inclui uma nova entidade
        /// </summary>
        /// <param name="model">Entidade que deve ser inserida</param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity model);

        /// <summary>
        /// Atualiza uma entidade
        /// </summary>
        /// <param name="id">Código da entidade que será atualizada</param>
        /// <param name="model">Dados que serão atualizados na entidade</param>
        /// <returns></returns>
        Task UpdateAsync(Guid id, TEntity model);

        /// <summary>
        /// Remove uma entidade
        /// </summary>
        /// <param name="id">Código da entidade que deve ser removida</param>
        /// <returns></returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Remove uma entidade
        /// </summary>
        /// <param name="model">Entidade a ser removida</param>
        /// <returns></returns>
        Task RemoveAsync(TEntity model);

        /// <summary>
        /// Realiza a consulta de uma entidade
        /// </summary>
        /// <param name="id">Código da entidade da entidade a ser consultada</param>
        /// <param name="expand">Indica se devem ser retornadas todas as propriedades filhas</param>
        /// <returns></returns>
        Task<TEntity> GetById(Guid id, bool expand);
    }
}