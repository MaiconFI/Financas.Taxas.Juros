using Financas.Taxas.Juros.Domain.Base;

namespace Financas.Taxas.Juros.Domain
{
    public abstract class TaxaDeJuros : BaseEntity
    {
        public TaxaDeJuros(decimal valor)
        {
            Valor = valor;
        }

        protected TaxaDeJuros()
        {
        }

        public decimal Valor { get; private set; }
    }
}