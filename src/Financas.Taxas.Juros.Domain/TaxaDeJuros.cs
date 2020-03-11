using Financas.Taxas.Juros.Domain.Base;

namespace Financas.Taxas.Juros.Domain
{
    public abstract class TaxaDeJuros : BaseEntity
    {
        public TaxaDeJuros(decimal valor)
        {
            ValidarValor(valor);

            if (!IsValid()) return;

            Valor = valor;
        }

        public decimal Valor { get; private set; }

        private void ValidarValor(decimal valor)
        {
            if (valor < default(decimal))
                AddError("O valor deve ser maior ou igual a zero.");
        }
    }
}