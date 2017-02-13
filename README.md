# Fuel Delivery System Project

### Fuel Delivery ERD

Below is the ERD that show the relationships between the 5 tables used.  The current database was created with a `Sqlite` format.
 - `Truck` - Record for each truck in the system.
  - `TruckId (int)` - Primary key
  - `OperatingRegionId (int)` - Foreign key to Assigned operating region.
  - `Name (string)` - Name given to the truck.
  - `Capacity (int)` - The amount of fuel in gallons a truck can hold.
  - `DateCreated (dateTime)` - Timestamp of when each truck was created.
 - `OperatingRegion` - Contains every region in the system. Each truck is assigned to a single region.
  - `OperatingRegionId (int)` - Primary key.
  - `Name (string)` - Name given to this region.
  - `Radius (int)` - Mile radius that this region covers.
  - `DateCreated (dateTime)` - Timestamp of when each region was created.
 - `Location` - Contains the locations or physical "stops" for that are contained in a region. A location can only belong to a single region.
  - `LocationId` - Primary key.
  - `OperatingRegionId` - Foreign key to locations region.
  - `Longitude (real)` - Longitude for location.
  - `Latitude (real)` - Latitude for location.
  - `PostalCode (int)` - Postal code for the location.
  - `DateCreated (dateTime)` - Timestamp of when each location was created.
 - `Trip` - Record for each daily trip the truck makes.
  - `TripId (int)` - Primary key.
  - `TruckId (int)` - Foreign key with truck id.
  - `DateCreated (dateTime)` - Timestamp of when each trip was created.
 - `Stop` - Record of each stop the truck makes within a trip. A truck will make at least 6 but no more than 20 stops based on the percentage of fuel a location receives per trip.
  - `StopId (int)` - Primary key.
  - `LocationId (int)` - Foreign key.
  - `FuelAmountUsed (int)` - The amount of fuel given to the location at this stop.
  - `FuelPercentageUser (int)` - The percentage of fuel that was given to the location at this stop.
  - `DateCreated (dateTime)` - Timestamp of when each stop was created.


<p align="center">
  <kbd>
    <img src="/FuelDeliveryERD.png" />
  </kbd>
</p>
