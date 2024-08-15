using TravelAccommodationBooking.Model.Enums.Image;
namespace TravelAccommodationBooking.BLL.DTO.Image;

public record ImageCreationDto
{
    public Guid EntityId { get; set; }
    public string Base64Content { get; set; }
    public ImageFormat Format { get; set; }
    public ImageCategory Type { get; set; }
}