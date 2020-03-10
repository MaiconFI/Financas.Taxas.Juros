using Financas.Taxas.Juros.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Financas.Taxas.Juros.Domain.Repositories
{
    public class TaxaDeJurosRepository : ITaxaDeJurosRepository
    {
        private readonly ITaxaDeJurosContext _taxaDeJurosContext;

        public TaxaDeJurosRepository(ITaxaDeJurosContext taxaDeJurosContext)
        {
            _taxaDeJurosContext = taxaDeJurosContext;
        }

        public async Task<T> GetTaxaDeJurosAsync<T>()
            where T : TaxaDeJuros
            => await _taxaDeJurosContext.TaxasDeJuros.OfType<T>().FirstOrDefaultAsync();
    }
}