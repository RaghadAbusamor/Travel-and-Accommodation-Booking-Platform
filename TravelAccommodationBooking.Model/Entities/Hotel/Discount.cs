using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAccommodationBooking.Model.Entities.Hotel
{
    public class Discount
    {
        public Guid Id { get; set; }
        public Guid RoomTypeId { get; set; }
        public float DiscountPercentage { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
