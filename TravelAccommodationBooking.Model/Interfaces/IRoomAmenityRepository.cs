using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Entities.Rooms;
using TravelAccommodationBooking.Model.Entities.Utilities;

namespace TravelAccommodationBooking.Model.Interfaces;

public interface IRoomAmenityRepository
{
    public Task<PaginatedList<RoomFeature>>
    GetAllAsync(string? searchQuery, int pageNumber, int pageSize);
    public Task<RoomFeature?> GetByIdAsync(Guid amenityId);
    public Task<RoomFeature?> InsertAsync(RoomFeature roomAmenity);
    public Task UpdateAsync(RoomFeature roomAmenity);
    public Task DeleteAsync(Guid amenityId);
    public Task SaveChangesAsync();
    public Task<bool> IsExistsAsync(Guid amenityId);
}