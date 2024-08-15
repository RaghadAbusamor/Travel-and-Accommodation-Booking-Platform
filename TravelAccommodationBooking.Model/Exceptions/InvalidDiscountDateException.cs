using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAccommodationBooking.Model.Exceptions
{
    public class InvalidDiscountDateException : Exception
    {
        public InvalidDiscountDateException()
            : base("There is an issue with the discount date. Please verify the dates are correct.")
        {
        }

        public InvalidDiscountDateException(string message)
            : base(message)
        {
        }
    }
}
