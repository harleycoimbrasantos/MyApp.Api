using DinkToPdf;

namespace MyApp.ReportService.File.Pdf
{
    public class PDF
    {
        public string? Body { get; set; }

        public ColorMode ColorMode { get; set; }

        public Orientation Orientation { get; set; }

        public PaperKind PaperKind { get; set; }
    }
}
