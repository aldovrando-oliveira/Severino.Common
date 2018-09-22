using System.Collections.Generic;

namespace Severino.Common.Paging
{
    /// <summary>
    /// Implementação do contrato <see cref="IListPaged"/>.
    /// Lista com as informações de paginação e resultado da consulta.
    /// </summary>
    public class ListPaged : List<object>, IListPaged
    {
        /// <inheritdoc />
        /// <summary>
        /// Informações de paginação da pesquisa
        /// </summary>
        public PageRequest Page { get; set; }
    }
    
    /// <summary>
    /// Implementação do contrato <see cref="IListPaged{T}"/>.
    /// Lista com as informações de paginação e resultado da consulta.
    /// </summary>
    public class ListPaged<T> : List<T>, IListPaged<T>
    {
        /// <inheritdoc />
        /// <summary>
        /// Informações de paginação da pesquisa
        /// </summary>
        public virtual PageResponse Page { get; set; }
    }
}