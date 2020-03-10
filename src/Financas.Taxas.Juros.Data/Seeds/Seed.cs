using Financas.Taxas.Juros.Data.Context;
using Financas.Taxas.Juros.Data.Seeds.Entities;
using System.Threading.Tasks;

namespace Financas.Taxas.Juros.Data.Seeds
{
    public class Seed
    {
        private readonly ITaxaDeJurosContext _taxaDeJurosContext;

        public Seed(ITaxaDeJurosContext taxaDeJurosContext)
        {
            _taxaDeJurosContext = taxaDeJurosContext;
        }

        public void Execute() => Task.WaitAll(ExecuteAsync());

        private async Task ExecuteAsync()
        {
            await new TaxaDeJurosSeed(_taxaDeJurosContext).ExecuteAsync();
            await _taxaDeJurosContext.SaveChangesAsync();
        }
    }
}