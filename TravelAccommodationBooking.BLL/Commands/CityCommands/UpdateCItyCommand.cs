using MediatR;

namespace TravelAccommodationBooking.BLL.Commands.CityCommands
{
    public record UpdateCityCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string PostOffice { get; set; }
    }
}