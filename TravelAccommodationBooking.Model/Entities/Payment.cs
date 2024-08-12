using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAccommodationBooking.Model.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }

        public Guid BookingId { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public double Amount { get; set; }

    }
}
