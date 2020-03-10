using Financas.Taxas.Juros.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.Taxas.Juros.Data.Configs
{
    public class TaxaDeJurosConfig : IEntityTypeConfiguration<TaxaDeJuros>
    {
        public void Configure(EntityTypeBuilder<TaxaDeJuros> builder)
        {
            builder.ToTable(nameof(TaxaDeJuros));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Valor).IsRequired();

            builder.HasDiscriminator<short>("Discriminator")
                .HasValue<TaxaDeJurosPadrao>(TaxaDeJurosPadrao.Discriminator)
                .HasValue<TaxaDeJurosBasica>(TaxaDeJurosBasica.Discriminator);
        }
    }
}