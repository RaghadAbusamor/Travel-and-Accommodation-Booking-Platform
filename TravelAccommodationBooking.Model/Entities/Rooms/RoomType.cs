using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Enums.Hotel;

namespace TravelAccommodationBooking.Model.Entities.Rooms
{
    public class RoomType
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public RoomCategory Category { get; set; }
        public float PricePerNight { get; set; }
        public IList<RoomFeature> Features { get; set; }
        public IList<Discount> Discounts { get; set; }


    }
}
