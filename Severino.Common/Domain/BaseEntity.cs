using System;

namespace Severino.Common.Domain
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; private set; }
        public virtual DateTime CreatedAt { get; set; }
    }
}