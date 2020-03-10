using Financas.Taxas.Juros.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Taxas.Juros.Data.Context
{
    public interface ITaxaDeJurosContext : IDisposable
    {
        DbSet<TaxaDeJuros> TaxasDeJuros { get; set; }

        bool AllMigrationsApplied();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Seed();
    }
}