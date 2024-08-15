namespace TravelAccommodationBooking.BLL.DTO.DIscount;

public record GetAllRoomTypeDiscountsDto
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
}