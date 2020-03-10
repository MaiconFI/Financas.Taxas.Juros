using AutoMapper;
using Financas.Taxas.Juros.Domain;
using Financas.Taxas.Juros.Domain.Repositories;
using Financas.Taxas.Juros.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Taxas.Juros.Queries.TaxasDeJuros
{
    public class TaxaDeJurosPadraoQueryHandler : IRequestHandler<TaxaDeJurosPadraoQuery, TaxaDeJurosDto>
    {
        private readonly IMapper _mapper;
        private readonly ITaxaDeJurosRepository _taxaDeJurosRepository;

        public TaxaDeJurosPadraoQueryHandler(IMapper mapper,
            ITaxaDeJurosRepository taxaDeJurosRepository)
        {
            _mapper = mapper;
            _taxaDeJurosRepository = taxaDeJurosRepository;
        }

        public async Task<TaxaDeJurosDto> Handle(TaxaDeJurosPadraoQuery request, CancellationToken cancellationToken)
        {
            var taxaDeJurosBasica = await _taxaDeJurosRepository.GetTaxaDeJurosAsync<TaxaDeJurosPadrao>();
            return _mapper.Map<TaxaDeJurosDto>(taxaDeJurosBasica);
        }
    }
}