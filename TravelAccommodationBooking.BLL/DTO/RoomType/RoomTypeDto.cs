using TravelAccommodationBooking.BLL.DTO.RoomFeature;

namespace TravelAccommodationBooking.BLL.DTO.RoomType;

public record RoomTypeDto
{
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public string Category { get; set; }
    public float PricePerNight { get; set; }
    public IList<RoomAmenityDto> Amenities { get; set; }
}