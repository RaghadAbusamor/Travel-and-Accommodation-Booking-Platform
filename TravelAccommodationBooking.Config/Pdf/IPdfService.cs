namespace TravelAccommodationBooking.Config.Pdf;

public interface IPdfService
{
    public Task<byte[]> CreatePdfFromHtmlAsync(string htmlContent);
}