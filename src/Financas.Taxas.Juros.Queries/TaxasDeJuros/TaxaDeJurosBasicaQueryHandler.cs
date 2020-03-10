using AutoMapper;
using Financas.Taxas.Juros.Domain;
using Financas.Taxas.Juros.Domain.Repositories;
using Financas.Taxas.Juros.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Taxas.Juros.Queries.TaxasDeJuros
{
    public class TaxaDeJurosBasicaQueryHandler : IRequestHandler<TaxaDeJurosBasicaQuery, TaxaDeJurosDto>
    {
        private readonly IMapper _mapper;
        private readonly ITaxaDeJurosRepository _taxaDeJurosRepository;

        public TaxaDeJurosBasicaQueryHandler(IMapper mapper,
            ITaxaDeJurosRepository taxaDeJurosRepository)
        {
            _mapper = mapper;
            _taxaDeJurosRepository = taxaDeJurosRepository;
        }

        public async Task<TaxaDeJurosDto> Handle(TaxaDeJurosBasicaQuery request, CancellationToken cancellationToken)
        {
            var taxaDeJurosBasica = await _taxaDeJurosRepository.GetTaxaDeJurosAsync<TaxaDeJurosBasica>();
            return _mapper.Map<TaxaDeJurosDto>(taxaDeJurosBasica);
        }
    }
}