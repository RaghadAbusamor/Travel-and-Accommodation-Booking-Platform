﻿using TravelAccommodationBooking.Model.Entities.Hotel;

namespace TravelAccommodationBooking.Model.Interfaces;

public interface IOwnerRepository
{
    public Task<IReadOnlyList<Owner>> GetAllAsync();
    public Task<Owner?> GetByIdAsync(Guid ownerId);
    Task<Owner?> InsertAsync(Owner owner);
    Task UpdateAsync(Owner owner);
    Task DeleteAsync(Guid ownerId);
    Task SaveChangesAsync();
    Task<bool> IsExistsAsync(Guid ownerId);
}