using System;
using System.Collections.Generic;

namespace Severino.Common.Repository
{
    /// <summary>
    /// Implementação do contrato IListPagedResponse.
    /// Lista com as informações de paginação e resultado da consulta.
    /// </summary>
    public class ListPaged<T> : IListPagedResponse<T>
    {
        /// <summary>
        /// Coleção com os resultados da pesquisa
        /// </summary>
        public virtual ICollection<T> Data { get; set; }

        /// <summary>
        /// Informações de paginação da pesquisa
        /// </summary>
        public virtual PageResponse Page { get; set; }
    }
}