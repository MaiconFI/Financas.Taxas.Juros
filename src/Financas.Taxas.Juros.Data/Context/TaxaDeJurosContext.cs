using Financas.Taxas.Juros.Data.Seeds;
using Financas.Taxas.Juros.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Financas.Taxas.Juros.Data.Context
{
    public class TaxaDeJurosContext : DbContext, ITaxaDeJurosContext
    {
        public TaxaDeJurosContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TaxaDeJuros> TaxasDeJuros { get; set; }

        public bool AllMigrationsApplied()
        {
            throw new NotImplementedException();
        }

        public void Seed() => new Seed(this).Execute();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ITaxaDeJurosContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}