using System;

namespace Severino.Common.Domain
{
    /// <summary>
    /// Classe base para entidades
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Identificador da entidade
        /// </summary>
        public virtual long Id { get; private set; }

        /// <summary>
        /// Data de criação da entidade
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }
    }
}