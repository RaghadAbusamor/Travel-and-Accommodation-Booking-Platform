using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelAccommodationBooking.Config.Common.Persistence;
using TravelAccommodationBooking.Model.Entities.Rooms;
using TravelAccommodationBooking.Model.Entities.Utilities;
using TravelAccommodationBooking.Model.Exceptions;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.Config.Common.Persistence.Repositories;

public class RoomAmenityRepository : IRoomAmenityRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RoomAmenityRepository> _logger;

    public RoomAmenityRepository(ApplicationDbContext context, ILogger<RoomAmenityRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<PaginatedList<RoomFeature>> GetAllAsync(string? searchQuery, int pageNumber, int pageSize)
    {
        try
        {
            var query = _context.RoomFeatures.AsQueryable();
            var totalItemCount = await query.CountAsync();
            var pageData = new PageData(totalItemCount, pageSize, pageNumber);

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                query = query.Where
                (city => city.Name.Contains(searchQuery) ||
                city.Description.Contains(searchQuery));
            }

            var result = query
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .AsNoTracking()
                .ToList();

            return new PaginatedList<RoomFeature>(result, pageData);
        }
        catch (Exception)
        {
            return new PaginatedList<RoomFeature>(new List<RoomFeature>(), new PageData(0, 0, 0));
        }
    }

    public async Task<RoomFeature?> GetByIdAsync(Guid amenityId)
    {
        try
        {
            var query = _context
                .RoomFeatures
                .AsQueryable();

            return await query
                .AsNoTracking()
                .SingleAsync
                    (amenity => amenity.Id.Equals(amenityId));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return null;
    }

    public async Task<RoomFeature?> InsertAsync(RoomFeature roomAmenity)
    {
        try
        {
            await _context.RoomFeatures.AddAsync(roomAmenity);
            await SaveChangesAsync();
            return roomAmenity;
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }

    public async Task UpdateAsync(RoomFeature roomAmenity)
    {
        try
        {
            _context.RoomFeatures.Update(roomAmenity);
            await SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new DataConstraintViolationException("Error updating the roomAmenity. Check for a violation of roomAmenity attributes.");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw new InvalidOperationException("Error Occured while updating roomAmenity.");
        }
    }

    public async Task DeleteAsync(Guid amenityId)
    {
        var amenityToRemove = new RoomFeature { Id = amenityId };
        _context.RoomFeatures.Remove(amenityToRemove);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsExistsAsync(Guid amenityId)
    {
        return await _context
            .RoomFeatures
            .AnyAsync
            (roomAmenity => roomAmenity.Id.Equals(amenityId));
    }
}