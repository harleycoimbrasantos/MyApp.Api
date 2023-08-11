using MediatR;
using MyApp.ReportService.File.Pdf;
using MyApp.ReportService.Interfaces;
using MyApp.ReportService.Templates;

namespace MyApp.Application.ReportTeste
{
    public class ReportHandler : IRequestHandler<ReportRequest, byte[]>
    {
        private readonly IPdfService _pdfService;

        public ReportHandler(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        public  Task<byte[]> Handle(ReportRequest request, CancellationToken cancellationToken)
        {
            PDF pdf =
                PdfBuilder.Create(GenerateTestTemplate())
                          .Build();

            return Task.FromResult(_pdfService.GeneratePDF(pdf));
        }


        private ITemplate GenerateTestTemplate()
        {
            TemplateExample template = new()
            {
                Name = "João das Neves",

                CartRows = new List<TemplateExampleList>
                {
                    new TemplateExampleList
                    {
                        Item = "Notebook",
                        Value = 2500
                    },
                    new TemplateExampleList
                    {
                        Item = "Kit teclado e mouse sem fio",
                        Value = 150
                    }
                },

                Total = new TemplateExampleList
                {
                    Item = "Total",
                    Value = 2650
                },
            };

            return template;
        }
    }
}
