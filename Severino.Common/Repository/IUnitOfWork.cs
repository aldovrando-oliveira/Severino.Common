using System.Threading.Tasks;

namespace Severino.Common.Repository
{
    /// <summary>
    /// Contrato para utilização do padrão 'Unit of Work'
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Realiza a consolidação das alterações no banco de dados
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}