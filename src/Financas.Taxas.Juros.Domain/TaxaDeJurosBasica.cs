namespace Financas.Taxas.Juros.Domain
{
    public class TaxaDeJurosBasica : TaxaDeJuros
    {
        public const short Discriminator = 2;
        public const decimal ValorDaTaxa = 4.25M;

        public TaxaDeJurosBasica()
            : base(ValorDaTaxa)
        {
        }
    }
}