using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FuelDeliverySystem.Models;

namespace FuelDeliverySystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            using (var context = new FuelDeliverySystemContext())
            {
                if (context.Truck.Any())
                {
                    return;
                }

                // Seed a few OperatingRegions to the DB (Needs to be first because of foreign key dependencies)
                var operatingRegions = new OperatingRegion[]
                {
                    new OperatingRegion { Name = "South Side", Radius = 50 },
                    new OperatingRegion { Name = "East Side", Radius = 30 },
                    new OperatingRegion { Name = "West Side", Radius = 60 },
                    new OperatingRegion { Name = "North Side", Radius = 25 },
                };

                foreach (OperatingRegion i in operatingRegions)
                {
                    context.OperatingRegion.Add(i);
                }
                context.SaveChangesAsync();

                // Seed a few Trucks to the DB
                var trucks = new Truck[]
                {
                    new Truck { 
                        Name = "Big 40", 
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "South Side").OperatingRegionId
                    },
                    new Truck { 
                        Name = "Johnny 5",
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "South Side").OperatingRegionId
                    },
                    new Truck { 
                        Name = "The Terminator", 
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "East Side").OperatingRegionId
                    },
                    new Truck { 
                        Name = "Blaze",
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "East Side").OperatingRegionId 
                    },
                    new Truck { 
                        Name = "Super Truck",
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "West Side").OperatingRegionId 
                    },
                    new Truck { 
                        Name = "18 Wheelin",
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "West Side").OperatingRegionId 
                    },
                    new Truck { 
                        Name = "The Night Hawk",
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "North Side").OperatingRegionId 
                    },
                    new Truck { 
                        Name = "Sleep Walker",
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "North Side").OperatingRegionId 
                    },
                };
                foreach (Truck i in trucks)
                {
                    context.Truck.Add(i);
                }
                context.SaveChangesAsync();

                //Seed a few locations to the DB in each operating region
                var locations = new Location[]
                {
                    new Location {
                        Name = "BP Fuel",
                        Longitude = 35.666222F,
                        Latitude = -96.679688F,
                        PostalCode = 37201,
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "South Side").OperatingRegionId
                    },
                    new Location {
                        Name = "American Gas",
                        Longitude = 35.666222F,
                        Latitude = -96.679688F,
                        PostalCode = 37201,
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "South Side").OperatingRegionId
                    },
                    new Location {
                        Name = "Exxon",
                        Longitude = 35.666222F,
                        Latitude = -96.679688F,
                        PostalCode = 37207,
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "East Side").OperatingRegionId
                    },
                    new Location {
                        Name = "Marathon Oil",
                        Longitude = 35.666222F,
                        Latitude = -96.679688F,
                        PostalCode = 37207,
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "East Side").OperatingRegionId
                    },
                    new Location {
                        Name = "Circle K",
                        Longitude = 35.666222F,
                        Latitude = -96.679688F,
                        PostalCode = 37204,
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "West Side").OperatingRegionId
                    },
                    new Location {
                        Name = "Mobil",
                        Longitude = 35.666222F,
                        Latitude = -96.679688F,
                        PostalCode = 37204,
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "West Side").OperatingRegionId
                    },
                    new Location {
                        Name = "Pilot",
                        Longitude = 35.666222F,
                        Latitude = -96.679688F,
                        PostalCode = 37205,
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "North Side").OperatingRegionId
                    },
                    new Location {
                        Name = "Phillips 66",
                        Longitude = 35.666222F,
                        Latitude = -96.679688F,
                        PostalCode = 37205,
                        OperatingRegionId = operatingRegions.Single(o => o.Name == "North Side").OperatingRegionId
                    },
                };

                foreach (Location i in locations)
                {
                    context.Location.Add(i);
                }
                context.SaveChangesAsync();
            }
        }
    }
}