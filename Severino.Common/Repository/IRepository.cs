using System;
using System.Threading.Tasks;
using Severino.Common.Domain;

namespace Severino.Common.Repository
{
    /// <summary>
    /// Contrato padrão para repositórios
    /// </summary>
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        /// <summary>
        /// Insere um novo item na base de dados
        /// </summary>
        /// <param name="item">Item a ser inserido</param>
        Task<T> AddAsync(T item);

        /// <summary>
        /// Atualiza o item na base de dados
        /// </summary>
        /// <param name="item">Item atualizado</param>
        Task UpdateAsync(T item);

        /// <summary>
        /// Remove o item da base de dados
        /// </summary>
        /// <param name="item">Item removido</param>
        Task RemoveAsync(T item);

        /// <summary>
        /// Realiza a consulta de um item pelo identificador
        /// </summary>
        /// <param name="id">Identificador para a pesquisa</param>
        Task<T> FindByIdAsync(long id);
    }
}