using NReco.PdfGenerator;

namespace TravelAccommodationBooking.Config.Pdf;

public class PdfService : IPdfService
{
    public async Task<byte[]> CreatePdfFromHtmlAsync(string html)
    {
        var htmlToPdfConverter = new HtmlToPdfConverter();
        return await Task.FromResult(htmlToPdfConverter.GeneratePdf(html));
    }
}