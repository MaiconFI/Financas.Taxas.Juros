using AutoMapper;
using Financas.Taxas.Juros.Data.Context;
using Financas.Taxas.Juros.Data.Seeds.Entities;
using Financas.Taxas.Juros.Domain;
using Financas.Taxas.Juros.Domain.Repositories;
using Financas.Taxas.Juros.Queries.Mappers;
using Financas.Taxas.Juros.Queries.TaxasDeJuros;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Xunit;

namespace Financas.Taxas.Juros.Queries.Tests
{
    public class TaxaDeJurosPadraoQueryHandlerTests
    {
        [Fact]
        public async void DeveRetornarATaxaDeJurosBasica()
        {
            var context = GetContext();
            var repository = new TaxaDeJurosRepository(context);
            var mapper = GetMapper();

            var seed = new TaxaDeJurosSeed(context);
            await seed.ExecuteAsync();
            await context.SaveChangesAsync();

            var query = new TaxaDeJurosPadraoQuery();
            var queryHandler = new TaxaDeJurosPadraoQueryHandler(mapper, repository);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(TaxaDeJurosPadrao.ValorDaTaxa, result.Valor);
        }

        private ITaxaDeJurosContext GetContext()
        {
            var options = new DbContextOptionsBuilder<TaxaDeJurosContext>()
                .UseInMemoryDatabase("Taxas.Juros.Tests").Options;
            return new TaxaDeJurosContext(options);
        }

        private IMapper GetMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaxaDeJurosQueriesProfile());
            });
            return mappingConfig.CreateMapper();
        }
    }
}