using TravelAccommodationBooking.BLL.DTO.Hotel;

namespace TravelAccommodationBooking.BLL.DTO.City;

public record CityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string PostOffice { get; set; } = string.Empty;
    public IList<HotelWithoutRoomsDto> Hotels { get; set; }
}