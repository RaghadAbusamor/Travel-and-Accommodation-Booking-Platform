﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelAccommodationBooking.Config.Common.Persistence;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Entities.User;
using TravelAccommodationBooking.Model.Exceptions;
using TravelAccommodationBooking.Model.Interfaces;


namespace TravelAccommodationBooking.Config.Common.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Guid> GetGuestIdByEmailAsync(string email)
    {
        return (await _context
            .Users
            .Where
            (user => user
                .Email
                .Equals(email))
            .SingleAsync()).Id;
    }
    public async Task InsertAsync(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            if (e.InnerException != null && e.InnerException.Message.Contains("Role"))
            {
                throw new UserAlreadyExistsException();
            }
            throw new DataConstraintViolationException("Error Adding User. Check for a violation of User attributes.");
        }
    }

    public async Task<IReadOnlyList<User>> GetAllAsync()
    {
        try
        {
            return await _context
                .Users
                .Include(user => user.Bookings)
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception)
        {
            return Array.Empty<User>();
        }
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        try
        {
            return await _context
                .Users
                .SingleAsync(user => user.Id.Equals(userId));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return null;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid userId)
    {
        var userToRemove = new User { Id = userId };
        _context.Users.Remove(userToRemove);
        await SaveChangesAsync();
    }

    public async Task<bool> IsExistsAsync(Guid userId)
    {
        return await _context
            .Users
            .AnyAsync
            (user => user.Id.Equals(userId));
    }

    public async Task<List<Hotel>> GetRecentlyVisitedHotelsForGuestAsync(Guid guestId, int count)
    {
        return await (from booking in _context.Bookings
                      join room in _context.Rooms on booking.RoomId equals room.Id
                      join roomType in _context.RoomTypes on room.RoomTypeId equals roomType.Id
                      join hotel in _context.Hotels on roomType.HotelId equals hotel.Id
                      where booking.UserId == guestId
                      orderby booking.CheckInDate descending
                      select hotel).Distinct().Take(count)
            .ToListAsync();
    }

    public async Task<List<Hotel>> GetRecentlyVisitedHotelsForAuthenticatedGuestAsync(string email, int count)
    {
        var guestId = await GetGuestIdByEmailAsync(email);
        return await GetRecentlyVisitedHotelsForGuestAsync(guestId, count);
    }

    public async Task<List<Booking>> GetBookingsForAuthenticatedGuestAsync(string email, int count)
    {
        var guestId = await GetGuestIdByEmailAsync(email);
        return await (from booking in _context.Bookings
                      where booking.UserId == guestId
                      orderby booking.CheckInDate descending
                      select booking)
            .Take(count)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}