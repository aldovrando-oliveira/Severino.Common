using System;
using System.Threading.Tasks;
using Severino.Common.Domain;

namespace Severino.Common.Repository
{
    /// <summary>
    /// Contrato padrão para repositórios
    /// </summary>
    public interface IBaseRepository<T> : IDisposable where T : BaseModel
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
        /// <param name="expand">Indica se devem ser retornadas entidades filhas</param>
        Task<T> GetByIdAsync(Guid id, bool expand);
    }
}