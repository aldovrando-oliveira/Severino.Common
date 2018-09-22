namespace Severino.Common.Paging
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
        /// Informaçoes da pagina
        /// </summary>
        public PageInfo Page { get; set; }

        /// <summary>
        /// Informaçoes da ordenaçao da consulta
        /// </summary>
        public SortInfo Sort { get; set; }

        /// <summary>
        /// Estrutura com as informaçoes da pagina da consulta
        /// </summary>
        public struct PageInfo
        {
            /// <summary>
            /// Quantidade total de paginas
            /// </summary>
            public long Total { get; set; }

            /// <summary>
            /// Pagina atual
            /// </summary>
            public long Current { get; set; }

            /// <summary>
            /// Tamanho da pagina
            /// </summary>
            public long Size { get; set; }
        }

        /// <summary>
        /// Estrutura com as informaçoes da ordenaçao da consulta
        /// </summary>
        public struct SortInfo
        {
            /// <summary>
            /// Nome da propriedade ordenada
            /// </summary>
            public string Property { get; set; }

            /// <summary>
            /// Sentido da ordenação
            /// </summary>
            public SortDirection Direction { get; set; }
        }
    }
}