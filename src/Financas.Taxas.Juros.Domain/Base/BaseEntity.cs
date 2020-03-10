using System;

namespace Financas.Taxas.Juros.Domain.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
    }
}