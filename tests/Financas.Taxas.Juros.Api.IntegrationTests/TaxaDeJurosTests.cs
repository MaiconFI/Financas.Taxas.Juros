using Financas.Taxas.Juros.Domain;
using Financas.Taxas.Juros.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Financas.Taxas.Juros.Api.IntegrationTests
{
    public class TaxaDeJurosTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TaxaDeJurosTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetTaxDeJurosBasica()
        {
            var resultadoEsperado = new TaxaDeJurosDto() { Valor = TaxaDeJurosPadrao.ValorDaTaxa };
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/v1/taxadejuros");
            response.EnsureSuccessStatusCode();
            var xpto = await response.Content.ReadAsStringAsync();
            var resultado = JsonSerializer.Deserialize<TaxaDeJurosDto>(xpto);

            Assert.Equal(resultadoEsperado.Valor, resultado.Valor);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}