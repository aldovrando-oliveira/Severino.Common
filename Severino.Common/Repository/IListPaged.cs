using System.Collections.Generic;

namespace Severino.Common.Repository
{
    /// <summary>
    /// Contrato de resposta para consultas com paginação
    /// </summary>
    public interface IListPagedRequest
    {
        /// <summary>
        /// Informações de paginação
        /// </summary>
        PageRequest Page { get; set; }
        
        /// <summary>
        /// Coleção com o resultado da consulta
        /// </summary>
        ICollection<object> Data { get; set; }
    }

    /// <summary>
    /// Contrato de resposta para consultas com paginação
    /// </summary>
    public interface IListPagedResponse<T>
    {
        /// <summary>
        /// Informações de paginação
        /// </summary>
        PageResponse Page { get; set; }

        /// <summary>
        /// Coleção com o resultado da consulta
        /// </summary>
        ICollection<T> Data { get; set; }
    }
}