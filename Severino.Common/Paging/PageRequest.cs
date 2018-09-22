namespace Severino.Common.Paging
{
    /// <summary>
    /// Classe com as informações de paginação para a realização da consulta
    /// </summary>
    public sealed class PageRequest
    {
        /// <summary>
        /// Tamanho da pagina (Padrão: 10)
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Pagina atual (Padrão: 1)
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Propriedade utilizada para ordenação
        /// </summary>
        public string SortProperty{ get; set; }

        /// <summary>
        /// Sentido da ordenação
        /// </summary>
        public SortDirection? SortDirection { get; set; }
    }
}