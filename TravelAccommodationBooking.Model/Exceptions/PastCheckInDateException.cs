using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAccommodationBooking.Model.Exceptions
{
    public class PastCheckInDateException : Exception
    {
        public PastCheckInDateException()
            : base("The check-in date for this booking has already passed.")
        {
        }

    }
}