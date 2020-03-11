namespace Financas.Taxas.Juros.Domain.Tests
{
    public class TaxaDeJurosInvalida : TaxaDeJuros
    {
        public const decimal ValorDaTaxa = -0.5M;

        public TaxaDeJurosInvalida()
            : base(ValorDaTaxa)
        {
        }
    }
}