using Financas.Taxas.Juros.Domain.Base;

namespace Financas.Taxas.Juros.Domain
{
    public abstract class TaxaDeJuros : BaseEntity
    {
        public TaxaDeJuros(decimal valor)
        {
            SetValor(valor);
        }

        protected TaxaDeJuros()
        {
        }

        public decimal Valor { get; private set; }

        private void SetValor(decimal valor)
        {
            if (valor <= default(decimal))
            {
                AddError("O valor dever ser maior que zero.");
                return;
            }

            Valor = valor;
        }
    }
}