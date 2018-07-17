using System.ComponentModel;

namespace Severino.Common.Service
{
    /// <summary>
    /// Enumerador com os tipos de erro
    /// </summary>
    public enum TypeError
    {
        /// <summary>
        /// Erro inesperado
        /// </summary>
        [Description("Unexpected error")]
        UnexpectedError,

        /// <summary>
        /// Não encontrado
        /// </summary>
        [Description("Not found")]
        NotFound,

        /// <summary>
        /// Propriedade inválida
        /// </summary>
        [Description("Invalid property")]
        PropertyInvalid,

        /// <summary>
        /// Conflito
        /// </summary>
        [Description("Conflict")]
        Conflict
    }
}