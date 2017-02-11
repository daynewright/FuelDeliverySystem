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
             
                var trips = new Trip[]
                {
                    new Trip {
                        TruckId = trucks.Single(t => t.Name == "Johnny 5").TruckId,
                        DateCreated = "2017-01-11 11:52:43"
                    },
                    new Trip {
                        TruckId = trucks.Single(t => t.Name == "Blaze").TruckId,
                        DateCreated = "2017-01-11 20:52:43"
                    },
                    new Trip {
                        TruckId = trucks.Single(t => t.Name == "Super Truck").TruckId,
                        DateCreated = "2016-12-11 20:52:43"
                    },
                    new Trip {
                        TruckId = trucks.Single(t => t.Name == "Sleep Walker").TruckId,
                        DateCreated = "2016-12-11 20:52:43"
                    }
                };

                foreach (Trip i in trips)
                {
                    context.Trip.Add(i);
                }
                context.SaveChangesAsync();

                // add a few stops to each trips
                var stops = new Stop[]
                {
                    new Stop {
                        TripId = trips.Single(tr => tr.TruckId == trucks.Single(t => t.Name == "Johnny 5").TruckId).TripId,
                        LocationId = locations.Single(l => l.Name == "BP Fuel").LocationId,
                        FuelAmountUsed = 900,
                        FuelPercentageUsed = 10,
                        DateCreated = "2017-01-11 12:34:43"
                    },
                    new Stop {
                        TripId = trips.Single(tr => tr.TruckId == trucks.Single(t => t.Name == "Johnny 5").TruckId).TripId,
                        LocationId = locations.Single(l => l.Name == "American Gas").LocationId,
                        FuelAmountUsed = 1350,
                        FuelPercentageUsed = 15,
                        DateCreated = "2017-01-11 13:25:43"
                    },
                    new Stop {
                        TripId = trips.Single(tr => tr.TruckId == trucks.Single(t => t.Name == "Blaze").TruckId).TripId,
                        LocationId = locations.Single(l => l.Name == "Exxon").LocationId,
                        FuelAmountUsed = 1530,
                        FuelPercentageUsed = 17,
                        DateCreated = "2017-01-11 14:25:43"
                    },
                    new Stop {
                        TripId = trips.Single(tr => tr.TruckId == trucks.Single(t => t.Name == "Blaze").TruckId).TripId,
                        LocationId = locations.Single(l => l.Name == "Marathon Oil").LocationId,
                        FuelAmountUsed = 1530,
                        FuelPercentageUsed = 17,
                        DateCreated = "2017-01-11 14:50:43"
                    },
                    new Stop {
                        TripId = trips.Single(tr => tr.TruckId == trucks.Single(t => t.Name == "Super Truck").TruckId).TripId,
                        LocationId = locations.Single(l => l.Name == "Circle K").LocationId,
                        FuelAmountUsed = 1530,
                        FuelPercentageUsed = 17,
                        DateCreated = "2017-01-11 12:43:43"
                    },
                    new Stop {
                        TripId = trips.Single(tr => tr.TruckId == trucks.Single(t => t.Name == "Super Truck").TruckId).TripId,
                        LocationId = locations.Single(l => l.Name == "Mobil").LocationId,
                        FuelAmountUsed = 1530,
                        FuelPercentageUsed = 17,
                        DateCreated = "2017-01-11 12:43:43"
                    },
                    new Stop {
                        TripId = trips.Single(tr => tr.TruckId == trucks.Single(t => t.Name == "Sleep Walker").TruckId).TripId,
                        LocationId = locations.Single(l => l.Name == "Pilot").LocationId,
                        FuelAmountUsed = 1530,
                        FuelPercentageUsed = 17,
                        DateCreated = "2017-01-11 12:43:43"
                    },
                    new Stop {
                        TripId = trips.Single(tr => tr.TruckId == trucks.Single(t => t.Name == "Sleep Walker").TruckId).TripId,
                        LocationId = locations.Single(l => l.Name == "Phillips 66").LocationId,
                        FuelAmountUsed = 1530,
                        FuelPercentageUsed = 17,
                        DateCreated = "2017-01-11 12:43:43"
                    }
                };
                
                foreach (Stop i in stops)
                {
                    context.Stop.Add(i);
                }
                context.SaveChangesAsync();
            }
        }
    }
}