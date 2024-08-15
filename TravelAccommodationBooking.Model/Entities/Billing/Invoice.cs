namespace TravelAccommodationBooking.Model.Entities.Billing
{
    public record Invoice
    {
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public double Price { get; set; }
        public string HotelName { get; set; }
        public string OwnerName { get; set; }
    }
}