using BookingSystem.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace BookingSystem.Persistence.Seeds
{
    public static class ResourceSeed
    {
        public static List<Resource> ResourceSeeds => new List<Resource>()
        {
            new Resource(1, Guid.Parse("08bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 1", 100, new List<Booking>()),
            new Resource(2, Guid.Parse("18bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 2", 200, new List<Booking>()),
            new Resource(3, Guid.Parse("28bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 3", 300, new List<Booking>()),
            new Resource(4, Guid.Parse("38bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 4", 400, new List<Booking>()),
            new Resource(5, Guid.Parse("48bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 5", 500, new List<Booking>()),
            new Resource(6, Guid.Parse("58bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 6", 600, new List<Booking>()),
            new Resource(7, Guid.Parse("68bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 7", 700, new List<Booking>()),
            new Resource(8, Guid.Parse("78bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 8", 800, new List<Booking>()),
            new Resource(9, Guid.Parse("88bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 9", 900, new List<Booking>()),
            new Resource(10, Guid.Parse("98bb3dde-09eb-453e-a2f2-d34183c0c5bb"), "Resource 10", 1000, new List<Booking>())
        };
    }
}
