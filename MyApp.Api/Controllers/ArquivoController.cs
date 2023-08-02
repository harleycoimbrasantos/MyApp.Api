using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.CNAB;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArquivoController : Controller
    {
        private readonly IMediator _mediator;

        public ArquivoController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpPost("processar-arquivo")]
        public async Task<Response> ProcessarArquivo(
            [FromBody] Request request,
            CancellationToken cancellationToken
        )
        {
            return await _mediator.Send(request, cancellationToken);
        }

        [HttpGet("check")]
        public  string GetHelthCheck(CancellationToken cancellationToken)
        {
            return "OK";
        }
    }
}
