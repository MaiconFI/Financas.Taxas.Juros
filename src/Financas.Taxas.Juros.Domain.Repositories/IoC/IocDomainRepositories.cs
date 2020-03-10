using Financas.Taxas.Juros.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Financas.Taxas.Juros.Domain.Queries.IoC
{
    public class IocDomainRepositories
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITaxaDeJurosRepository, TaxaDeJurosRepository>();
        }
    }
}