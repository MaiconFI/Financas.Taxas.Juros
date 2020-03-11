using System;
using Xunit;

namespace Financas.Taxas.Juros.Domain.Tests
{
    public class TaxaDeJurosTests
    {
        [Fact]
        public void TaxaDeJuros_DeveDispararExcecaoQuandoValorMenorQueZero()
        {
            static void acao() => new TaxaDeJurosInvalida();

            Assert.Throws<ArgumentException>(acao);
        }

        [Fact]
        public void TaxaDeJuros_DevePossuirValorDaTaxaPadrao()
        {
            var taxaDeJurosPadrao = new TaxaDeJurosPadrao();

            Assert.Equal(TaxaDeJurosPadrao.ValorDaTaxa, taxaDeJurosPadrao.Valor);
        }
    }
}