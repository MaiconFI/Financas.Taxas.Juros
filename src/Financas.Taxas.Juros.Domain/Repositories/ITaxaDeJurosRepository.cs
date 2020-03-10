using System.Threading.Tasks;

namespace Financas.Taxas.Juros.Domain.Repositories
{
    public interface ITaxaDeJurosRepository
    {
        Task<T> GetTaxaDeJurosAsync<T>() where T : TaxaDeJuros;
    }
}