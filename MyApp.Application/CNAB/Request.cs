using MediatR;


namespace MyApp.Application.CNAB
{
    public class Request : IRequest<Response>
    {
        public string? Base64 { get; set; }
    }
}