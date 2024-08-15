using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAccommodationBooking.Model.Enums.Payment
{
    public enum PaymentStatus
    {
        InProgress = 0,
        Paid = 1,
        Refunded = 2,
        Cancelled = 3
    }
}
