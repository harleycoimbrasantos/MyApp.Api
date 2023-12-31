﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.CNAB;
using MyApp.Application.ReportTeste;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArquivoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private Serilog.ILogger _logger;

        public ArquivoController(
            IMediator mediator, 
            Serilog.ILogger logger 
        )
        {
            _mediator = mediator;
            _logger = logger;
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
            _logger.Information("TESTE LOG");

            return "OK";
        }

       [HttpGet("tests/pdf")]
       public async Task<IActionResult> PdfTeste([FromQuery] ReportRequest request,
            CancellationToken cancellationToken)
        {
            byte[] pdf = await _mediator.Send(request);

            return File(pdf, "application/pdf", "exemplo.pdf");
        }

        [HttpGet("GetAll")]
        public async Task<GetCustomerMovementAllResponse> GetAll(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetCustomerMovementAllRequest() { }, cancellationToken);
        }

    }
}
