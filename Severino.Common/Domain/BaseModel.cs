using System;

namespace Severino.Common.Domain
{
    /// <summary>
    /// Classe base para entidades
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Identificador da entidade
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Data de criação da entidade
        /// </summary>
        public virtual DateTimeOffset CreatedAt { get; set; }
        
        /// <summary>
        /// Data da ultima atualizaçao da entidade
        /// </summary>
        public virtual DateTimeOffset UpdatedAt { get; set; }
    }
}