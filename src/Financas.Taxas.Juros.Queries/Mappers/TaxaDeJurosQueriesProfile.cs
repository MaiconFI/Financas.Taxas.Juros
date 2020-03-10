using AutoMapper;
using Financas.Taxas.Juros.Domain;
using Financas.Taxas.Juros.Dtos;

namespace Financas.Taxas.Juros.Queries.Mappers
{
    public class TaxaDeJurosQueriesProfile : Profile
    {
        public TaxaDeJurosQueriesProfile()
        {
            CreateMap<TaxaDeJuros, TaxaDeJurosDto>().ConvertUsing<TaxaDeJurosToTaxaDeJurosDtoConverter>();
        }
    }
}