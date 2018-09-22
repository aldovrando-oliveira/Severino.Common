using System.Collections;
using System.Collections.Generic;

namespace Severino.Common.Paging
{
    /// <summary>
    /// Contrato de resposta para consultas com paginação
    /// </summary>
    public interface IListPaged : IList
    {
        /// <summary>
        /// Informações de paginação
        /// </summary>
        PageRequest Page { get; set; }
    }

    /// <inheritdoc />
    /// <summary>
    /// Contrato de resposta para consultas com paginação
    /// </summary>
    /// <typeparam name="T">Tipo da lista</typeparam>
    public interface IListPaged<T> : IList<T>
    {
        /// <summary>
        /// Informações de paginação
        /// </summary>
        PageResponse Page { get; set; }
    }
}