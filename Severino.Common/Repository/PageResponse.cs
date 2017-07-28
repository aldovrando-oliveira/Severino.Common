namespace Severino.Common.Repository
{
    /// <summary>
    /// Classe com as informaões de paginação do resultado da consulta
    /// </summary>
    public sealed class PageResponse
    {
        /// <summary>
        /// Quantidade total de registros
        /// </summary>
        public long RecordCount { get; set; }

        /// <summary>
        /// Quantidade total de paginas
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Pagina atual
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Tamanho da pagina
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Propriedade utilizada para ordenação
        /// </summary>
        public string SortProperty { get; set; }

        /// <summary>
        /// Sentido da ordenação
        /// </summary>
        public SortDirection SortDirection { get; set; }
    }
}