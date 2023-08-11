using MyApp.ReportService.File.Models;

namespace MyApp.ReportService.Templates
{
    public class TemplateExample : Template
    {
        public TemplateExample()
        {
            CartRows = Enumerable.Empty<TemplateExampleList>();
        }

        public string Name { get; set; }

        public TemplateExampleList Total { get; set; }

        public IEnumerable<TemplateExampleList> CartRows { get; set; }
    }
}
