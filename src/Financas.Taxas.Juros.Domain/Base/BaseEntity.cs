using System;

namespace Financas.Taxas.Juros.Domain.Base
{
    public abstract class BaseEntity : BaseError
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}