﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelAccommodationBooking.Config.Common.Persistence;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.Config.Common.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger _logger;

    public PaymentRepository(ApplicationDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IReadOnlyList<Payment>> GetAllAsync()
    {
        try
        {
            return await _context
                .Payments
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception)
        {
            return Array.Empty<Payment>();
        }
    }

    public async Task<Payment?> GetByIdAsync(Guid paymentId)
    {
        try
        {
            return await _context
                .Payments
                .SingleAsync(payment => payment.Id.Equals(paymentId));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return null;
    }

    public async Task<Payment?> InsertAsync(Payment payment)
    {
        try
        {
            await _context.Payments.AddAsync(payment);
            await SaveChangesAsync();
            return payment;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }

    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid paymentId)
    {
        var paymentToRemove = new Payment { Id = paymentId };
        _context.Payments.Remove(paymentToRemove);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsExistsAsync(Guid paymentId)
    {
        return await _context
            .Payments
            .AnyAsync
            (payment => payment.Id.Equals(paymentId));
    }
}