using Financas.Taxas.Juros.Domain.Base;
using System;

namespace Financas.Taxas.Juros.Domain
{
    public abstract class TaxaDeJuros : BaseEntity
    {
        public TaxaDeJuros(decimal valor)
        {
            ValidarValor(valor);

            Valor = valor;
        }

        public decimal Valor { get; private set; }

        private void ValidarValor(decimal valor)
        {
            if (valor < default(decimal))
                throw new ArgumentException("O valo deve ser maior quer zero");
        }
    }
}