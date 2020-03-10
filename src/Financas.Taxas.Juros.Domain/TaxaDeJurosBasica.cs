namespace Financas.Taxas.Juros.Domain
{
    public class TaxaDeJurosBasica : TaxaDeJuros
    {
        public const decimal ValorDaTaxa = 0.01M;

        public TaxaDeJurosBasica()
            : base(ValorDaTaxa)
        {
        }
    }
}