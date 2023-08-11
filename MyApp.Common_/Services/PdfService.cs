using DinkToPdf;
using DinkToPdf.Contracts;
using MyApp.ReportService.File.Pdf;
using MyApp.ReportService.Interfaces;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Data;
using System.Drawing;


namespace MyApp.ReportService.Services
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public async Task<byte[]> Generate(DataTable theData)
        {
            byte[] _bytesArray;

            _bytesArray = null;
            if (theData != null)
            {
                PdfDocument _pdf = new PdfDocument();
                PdfPageBase _pagina = _pdf.Pages.Add();
                foreach (DataRow row in theData.Rows)
                {
                    PdfFont _fonte = new PdfFont(PdfFontFamily.Helvetica, 13f);
                    PdfBrush _cor = PdfBrushes.Red;

                    PointF _posicao = new PointF(20, 20);
                    _pagina.Canvas.DrawString(row[0].ToString(), _fonte, _cor, _posicao);

                    _posicao = new PointF(20, 40);
                    _pagina.Canvas.DrawString(row[1].ToString(), _fonte, _cor, _posicao);

                    _posicao = new PointF(20, 60);
                    _pagina.Canvas.DrawString(row[2].ToString(), _fonte, _cor, _posicao);
                }

                MemoryStream _ms = new MemoryStream();
                _pdf.SaveToStream(_ms);
                _bytesArray = _ms.ToArray();
            }
            return await Task.Run(() => _bytesArray);
        }

        public async Task<byte[]> Generate(List<String> theData)
        {
            byte[] _bytesArray;

            _bytesArray = null;
            if (theData != null)
            {
                PdfDocument _pdf = new PdfDocument();
                PdfPageBase _pagina = _pdf.Pages.Add();
                foreach (String _texto in theData)
                {
                    PdfFont _fonte = new PdfFont(PdfFontFamily.Helvetica, 13f);
                    PdfBrush _cor = PdfBrushes.Red;

                    PointF _posicao = new PointF(20, 20);
                    _pagina.Canvas.DrawString(_texto, _fonte, _cor, _posicao);
                }

                MemoryStream _ms = new MemoryStream();
                _pdf.SaveToStream(_ms);
                _bytesArray = _ms.ToArray();
            }
            return await Task.Run(() => _bytesArray);
        }

        public async Task<byte[]> Generate(String[] theData)
        {
            byte[] _bytesArray;

            _bytesArray = null;
            if (theData != null)
            {
                PdfDocument _pdf = new PdfDocument();
                PdfPageBase _pagina = _pdf.Pages.Add();
                foreach (String _texto in theData)
                {
                    PdfFont _fonte = new PdfFont(PdfFontFamily.Helvetica, 13f);
                    PdfBrush _cor = PdfBrushes.Red;

                    PointF _posicao = new PointF(20, 20);
                    _pagina.Canvas.DrawString(_texto, _fonte, _cor, _posicao);
                }

                MemoryStream _ms = new MemoryStream();
                _pdf.SaveToStream(_ms);
                _bytesArray = _ms.ToArray();
            }
            return await Task.Run(() => _bytesArray);
        }

        public byte[] GeneratePDF(PDF pdf)
        {
            HtmlToPdfDocument document = new()
            {
                GlobalSettings =
                {
                    ColorMode = pdf.ColorMode,
                    Orientation = pdf.Orientation,
                    PaperSize = pdf.PaperKind,
                },
                Objects =
                {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = pdf.Body,
                        WebSettings =
                        {
                            DefaultEncoding = "utf-8"
                        },
                        HeaderSettings =
                        {
                            FontSize = 6,
                            Right = "Página [page] de [toPage]",
                            Spacing = 3
                        }
                    }
                }
            };

            return _converter.Convert(document);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
