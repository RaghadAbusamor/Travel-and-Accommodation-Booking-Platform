﻿
using TravelAccommodationBooking.Model.Entities.Hotel;

namespace TravelAccommodationBooking.Model.Interfaces;

public interface IPaymentRepository
{
    public Task<IReadOnlyList<Payment>> GetAllAsync();
    public Task<Payment?> GetByIdAsync(Guid paymentId);
    Task<Payment?> InsertAsync(Payment payment);
    Task UpdateAsync(Payment payment);
    Task DeleteAsync(Guid paymentId);
    Task SaveChangesAsync();
    Task<bool> IsExistsAsync(Guid paymentId);
}