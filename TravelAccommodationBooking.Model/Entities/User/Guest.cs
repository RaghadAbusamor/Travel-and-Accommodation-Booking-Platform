using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAccommodationBooking.Model.Enums.User;
using TravelAccommodationBooking.Model.Entities.Hotel;
namespace TravelAccommodationBooking.Model.Entities.User
{
    public class Guest : Member
    {
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }
        public IList<Booking> Bookings { get; set; }

    }
}
