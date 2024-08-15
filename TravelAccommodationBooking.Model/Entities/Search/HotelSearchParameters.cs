using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAccommodationBooking.Model.Entities.Search
{
    public record HotelSearchParameters
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string? CityName { get; set; }
        public float StarRate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
