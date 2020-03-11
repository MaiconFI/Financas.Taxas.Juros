using System.Linq;
using Xunit;

namespace Financas.Taxas.Juros.Domain.Tests
{
    public class TaxaDeJurosTests
    {
        [Fact]
        public void TaxaDeJuros_DeveConterErrosQuandoValorMenorQueZero()
        {
            var taxaDeJurosInvalida = new TaxaDeJurosInvalida();

            Assert.True(taxaDeJurosInvalida.Errors.Any());
            Assert.Equal(default, taxaDeJurosInvalida.Valor);
        }

        [Fact]
        public void TaxaDeJuros_DevePossuirValorDaTaxaPadrao()
        {
            var taxaDeJurosPadrao = new TaxaDeJurosPadrao();

            Assert.Equal(TaxaDeJurosPadrao.ValorDaTaxa, taxaDeJurosPadrao.Valor);
        }
    }
}