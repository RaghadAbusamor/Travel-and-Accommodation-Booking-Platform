﻿using Microsoft.AspNetCore.Identity;
using TravelAccommodationBooking.Model.Entities.Hotel;

namespace TravelAccommodationBooking.Config.Common.Persistence.Seeding;

public class OwnerSeeding
{
    public static List<Owner> SeedData()
    {
        return new List<Owner>
        {
            new()
            {
                Id = new Guid("55b1aa11-12e7-4e0f-8425-67c1c1e62c2d"),
                FirstName = "Raghad",
                LastName = "AbuSamor",
                Email = "raghadmohammad253@gmail.com",
                PhoneNumber = "0595758383",
                PasswordHash = "55b1aa11precomputed_hash_value",
                Salt = "55b1aa11precomputed_salt_value",


            },
            new()
            {
                Id = new Guid("77b2c30b-65d0-4ea7-8a5e-71e7c294f117"),
                FirstName = "Ayat",
                LastName = "AbuAllam",
                Email = "ayatalan@gmail.com",
                PhoneNumber = "0595758382",
                PasswordHash = "77b2c30bprecomputed_hash_value22",
                Salt = "77b2c30precomputed_salt_value",

            }
        };
    }
}