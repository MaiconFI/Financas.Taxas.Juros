using AutoMapper;
using Financas.Taxas.Juros.Domain;
using Financas.Taxas.Juros.Dtos;

namespace Financas.Taxas.Juros.Queries.Mappers
{
    public class TaxaDeJurosToTaxaDeJurosDtoConverter : ITypeConverter<TaxaDeJuros, TaxaDeJurosDto>
    {
        public TaxaDeJurosDto Convert(TaxaDeJuros source, TaxaDeJurosDto destination, ResolutionContext context)
            => new TaxaDeJurosDto()
            {
                Valor = source.Valor
            };
    }
}