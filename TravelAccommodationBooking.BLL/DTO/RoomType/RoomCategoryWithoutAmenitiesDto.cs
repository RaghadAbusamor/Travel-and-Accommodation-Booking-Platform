namespace TravelAccommodationBooking.BLL.DTO.RoomType;

public record RoomCategoryWithoutAmenitiesDto
{
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public string Category { get; set; }
    public float PricePerNight { get; set; }
}