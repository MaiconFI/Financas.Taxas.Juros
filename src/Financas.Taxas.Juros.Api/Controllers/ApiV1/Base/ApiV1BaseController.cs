using Financas.Taxas.Juros.Dtos.Base;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Financas.Taxas.Juros.Api.Controllers.ApiV1.Base
{
    [ApiController]
    [ApiVersion("1")]
    public abstract class ApiV1BaseController : ControllerBase
    {
        protected IActionResult TratarRetorno(BaseDto dto)
            => dto.Errors?.Any() ?? true
                ? (IActionResult)BadRequest(dto)
                : Ok(dto);
    }
}