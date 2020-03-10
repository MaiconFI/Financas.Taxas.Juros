using System.Threading.Tasks;

namespace Financas.Taxas.Juros.Data.Seeds
{
    public interface IEntitySeed
    {
        Task ExecuteAsync();
    }
}