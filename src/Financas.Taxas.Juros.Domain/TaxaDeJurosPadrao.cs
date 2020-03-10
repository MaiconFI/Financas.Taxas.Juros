namespace Financas.Taxas.Juros.Domain
{
    public class TaxaDeJurosPadrao : TaxaDeJuros
    {
        public const short Discriminator = 1;
        public const decimal ValorDaTaxa = 0.01M;

        public TaxaDeJurosPadrao()
            : base(ValorDaTaxa)
        {
        }
    }
}