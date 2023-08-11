using MyApp.ReportService.File.Pdf;
using System.Data;

namespace MyApp.ReportService.Interfaces
{
    public interface IPdfService : IDisposable
    {
        Task<byte[]> Generate(DataTable theData);

        Task<byte[]> Generate(List<String> theData);

        Task<byte[]> Generate(String[] theData);

        byte[] GeneratePDF(PDF pdf);
    }
}
