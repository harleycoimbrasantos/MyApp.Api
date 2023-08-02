using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyApp.Application.CNAB
{
    public class Request : IRequest<Response>
    {
        public string Base64 { get; set; }
    }
}
