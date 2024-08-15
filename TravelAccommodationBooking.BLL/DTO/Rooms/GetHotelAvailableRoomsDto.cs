namespace TravelAccommodationBooking.BLL.DTO.Room;

public record GetHotelAvailableRoomsDto
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}