﻿using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Entities.Utilities;

namespace TravelAccommodationBooking.Model.Interfaces;

public interface IDiscountRepository
{
    public Task<PaginatedList<Discount>>
    GetAllByRoomTypeIdAsync(Guid roomTypeId, int pageNumber, int pageSize);
    public Task<Discount?> GetByIdAsync(Guid discountId);
    public Task<bool> HasOverlappingDiscountAsync(Guid roomTypeId,
        DateTime fromDate,
        DateTime toDate);
    public Task<Discount?> InsertAsync(Discount discount);
    public Task DeleteAsync(Guid discountId);
    public Task SaveChangesAsync();
    public Task<bool> IsExistsAsync(Guid discountId);
}