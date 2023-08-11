using MediatR;

namespace MyApp.Application.ReportTeste
{
    public class ReportRequest : IRequest<byte[]>
    {
        public string? Name { get; set; }
    }
}
