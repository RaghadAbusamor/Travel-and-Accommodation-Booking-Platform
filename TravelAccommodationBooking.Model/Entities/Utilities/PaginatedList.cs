using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAccommodationBooking.Model.Entities.Utilities
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set; }
        public PageData PageData { set; get; }

        public PaginatedList(List<T> items, PageData pageData)
        {
            Items = items;
            PageData = pageData;
        }
    }
}

