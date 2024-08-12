using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAccommodationBooking.Model.Entities
{
    public class Guest : User
    {
        public IList<Booking> Bookings { get; set; }

    }
}
