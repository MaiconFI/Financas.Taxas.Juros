using Financas.Taxas.Juros.Api.Controllers.ApiV1.Base;
using Financas.Taxas.Juros.Queries.TaxasDeJuros;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Taxas.Juros.Api.Controllers.ApiV1
{
    [Route("v{version:apiVersion}/taxaJuros")]
    public class TaxaDeJurosV1Controller : ApiV1BaseController
    {
        private readonly IMediator _mediator;

        public TaxaDeJurosV1Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            return TratarRetorno(await _mediator.Send(new TaxaDeJurosPadraoQuery(), cancellationToken));
        }
    }
}