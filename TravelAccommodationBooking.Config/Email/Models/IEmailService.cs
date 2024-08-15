using TravelAccommodationBooking.Config.Email;

namespace TravelAccommodationBooking.Config.Email.Models;

public interface IEmailService
{
    public Task SendEmailAsync(EmailMessage message, List<FileAttachment> attachments);
}