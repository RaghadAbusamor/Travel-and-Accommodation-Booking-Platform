namespace TravelAccommodationBooking.BLL.DTO.Rooms;

public record GetHotelAvailableRoomsDto
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}