using Financas.Taxas.Juros.Data.Context;
using Financas.Taxas.Juros.Domain;
using System.Threading.Tasks;

namespace Financas.Taxas.Juros.Data.Seeds.Entities
{
    public class TaxaDeJurosSeed : IEntitySeed
    {
        private readonly ITaxaDeJurosContext _taxaDeJurosContext;

        public TaxaDeJurosSeed(ITaxaDeJurosContext taxaDeJurosContext)
        {
            _taxaDeJurosContext = taxaDeJurosContext;
        }

        public async Task ExecuteAsync()
        {
            var taxaDeJurosBasica = new TaxaDeJurosBasica();
            await _taxaDeJurosContext.TaxasDeJuros.AddAsync(taxaDeJurosBasica);
        }
    }
}