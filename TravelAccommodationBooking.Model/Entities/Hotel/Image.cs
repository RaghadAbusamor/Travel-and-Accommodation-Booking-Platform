using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAccommodationBooking.Model.Enums.Image;

namespace TravelAccommodationBooking.Model.Entities.Hotel
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public string Url { get; set; }
        public ImageCategory Type { get; set; }
        public ImageFormat Format { get; set; }
    }
}
