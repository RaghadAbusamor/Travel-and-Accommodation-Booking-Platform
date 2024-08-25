using System;
using System.Collections.Generic;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Entities.User;
using TravelAccommodationBooking.Model.Enums.User;

namespace TravelAccommodationBooking.Config.Common.Persistence.Seeding
{
    public class UserSeeding
    {
        public static List<User> SeedData()
        {
            return new List<User>
            {
                new User
                {
                    Id = new Guid("c6c45f7c-2dfe-4c1e-9a9b-8b173c71b32c"),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com",
                    PhoneNumber = "1234567890",
                    PasswordHash = "c6c45f7cprecomputed_hash_value",
                    Salt = "c6c45f7cprecomputed_salt_value",
                    Role = UserRole.Guest,
              //      Bookings = new List<Booking>() 
                },
                new User
                {
                    Id = new Guid("aaf21a7d-8fc3-4c9f-8a8e-1eeec8dcd462"),
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "janesmith@example.com",
                    PhoneNumber = "0987654321",
                    PasswordHash = "aaf21a7dprecomputed_hash_value",
                    Salt = "aaf21a7dprecomputed_salt_value",
                    Role = UserRole.Guest,
                 //   Bookings = new List<Booking>() 
                },
                new User
                {
                    Id = new Guid("f44c3eb4-2c8a-4a77-a31b-04c4619aa15a"),
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alicejohnson@example.com",
                    PhoneNumber = "1122334455",
                    PasswordHash = "f44c3eb4precomputed_hash_value",
                    Salt = "f44c3eb4precomputed_salt_value",
                    Role = UserRole.Guest,
                }
            };
        }
    }
}
