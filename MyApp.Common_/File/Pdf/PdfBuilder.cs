using DinkToPdf;

namespace MyApp.ReportService.File.Pdf
{
    public class PdfBuilder
    {
        protected string Body { get; set; }

        protected ColorMode ColorMode { get; set; }

        protected Orientation Orientation { get; set; }

        protected PaperKind PaperKind { get; set; }

        public static PdfBuilder Create(string body)
        {
            return new PdfBuilder
            {
                ColorMode = ColorMode.Grayscale,
                Orientation = Orientation.Portrait,
                PaperKind = PaperKind.A4,
                Body = body
            };
        }

        public static PdfBuilder Create(ITemplate template)
        {
            return Create(template.Build());
        }

        public PdfBuilder WithColorMode(ColorMode colorMode)
        {
            ColorMode = colorMode;

            return this;
        }

        public PdfBuilder WithOrientation(Orientation orientation)
        {
            Orientation = orientation;

            return this;
        }

        public PdfBuilder WithPaperKind(PaperKind paperKind)
        {
            PaperKind = paperKind;

            return this;
        }

        public PDF Build()
        {
            return new PDF
            {
                ColorMode = ColorMode,
                Orientation = Orientation,
                PaperKind = PaperKind,
                Body = Body
            };
        }
    }
}
