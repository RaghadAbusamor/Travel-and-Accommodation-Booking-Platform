namespace TravelAccommodationBooking.BLL.DTO.Booking;

public record ReserveRoomDto
{
    public Guid RoomId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}