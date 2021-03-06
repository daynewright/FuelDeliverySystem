# Fuel Delivery System Project

## Table of Contents

- [Fuel Delivery ERD](#fuel-delivery-erd)
  - [Column Definitions](#definitions)
  - [Diagram](#diagram)
- [User Stories](#user-stories)
  - [Desktop Application](#desktop-application)
  - [Embedded Truck System](#embedded-truck-system)
  - [Web Service API](#web-service-api)
- [Database Queries](#database-queries)
  - [Top 10 Last 12 Months](#top-10-last-12-months)
  - [Avg Fuel Location By Month](#avg-fuel-location-by-month)


## Fuel Delivery ERD

Below is the ERD that show the relationships between the 5 tables used.  The current database was created with a `Sqlite` format.

### Definitions
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
 - `Location` - Contains the locations or physical "stops" that are contained in a region. A location can only belong to a single region.
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

### Diagram
<p align="center">
  <kbd>
    <img src="/FuelDeliveryERD.png" />
  </kbd>
</p>

## User Stories
_(Also listed as issues [here](https://github.com/daynewright/FuelDeliverySystem/issues))_

### Desktop Application

#### DISPATCH TRUCK FROM BASE
 **Given** a truck has refueled at base <br/>
 **When** the dispatcher receives the notification <br />
 **Then** the dispatcher sends web service new trip <br />
 **Then** the dispatcher sends the truck a starting destination within its operating region <br />

#### DISPATCH TRUCK TO NEXT LOCATION
 **Given** a truck has completed a location drop off <br />
 **And** the truck has fuel remaining <br />
 **When** the dispatcher receives the notification <br />
 **Then** the dispatcher sends the truck a new destination within its operating region

#### DISPATCH TRUCK BACK TO BASE
 **Given** a truck has completed a location drop off <br />
 **And** the truck has no fuel remaining <br />
 **When** the dispatcher receives the notification <br />
 **Then** the dispatcher sends the truck a notification to go to base

### Embedded Truck System

#### TRAVEL TO FIRST LOCATION
  **Given** a truck is at base <br />
  **When** the truck has refueled <br />
  **Then** the truck will notify the dispatcher it is ready for a location in its operating region

#### TRAVEL TO NEXT LOCATION
  **Given** a truck is at a location <br />
  **When** the truck has delivered fuel <br />
  **Then** the truck will notify the dispatcher it is ready for instructions

### Web Service API

#### TRUCK SENDS POST REQUEST AFTER STOP
  **Given** a truck is at a location <br />
  **When** the truck has finished fueling <br />
  **Then** the truck will `POST` to the Web Service API with the `locationId` / `TripId` / `FuelPercentageUsed` / `FuelAmountUsed`

#### DISPATCHER NOTIFIED OF TRUCK POST REQUEST
  **Given** a truck is at a location <br />
  **And** the truck has finished fueling <br />
  **And** the truck has sent a `POST` request to the Web Service API <br />
  **Then** the Web Service API will send a notification to the Dispatcher

#### DISPATCHER SENDS POST REQUEST WITH NEXT LOCATION
  **Given** a dispatcher has been notified of a truck `POST` <br />
  **Then** the dispatcher will send a `GET` for new data <br />
  **Then** the dispatcher will `POST` with new location data

#### TRUCK NOTIFIED OF DISPATCHER POST REQUEST
  **Given** a dispatcher has set a `POST` with new location data <br />
  **Then** the truck will be notified of the next location to travel

## Database Queries
_(Queries are based on Sqlite)_

#### TOP 10 LAST 12 MONTHS
[Query File](https://github.com/daynewright/FuelDeliverySystem/blob/master/Data/Queries/Avg_Fuel_Location_Month_Name.sql)
```
/*
 Selects the top 10 locations in the last 12 months that received fuel deliveries.
 Lists them descending by fuel delivery total.
*/

SELECT L.Name AS "Location Name",
SUM(FuelAmountUsed) AS "Fuel Received"
FROM Location AS L INNER JOIN Stop AS S
ON L.LocationId == S.LocationId
WHERE S.DateCreated BETWEEN DATE('now', 'start of month', '-11 months') AND DATE('now')
GROUP BY L.Name
ORDER BY "Fuel Received" DESC
LIMIT 10;
```

#### AVG FUEL LOCATION BY MONTH
[Query File](https://github.com/daynewright/FuelDeliverySystem/blob/master/Data/Queries/Avg_Fuel_Location_Month_Number.sql)
```
/*
 Selects the average fuel consumption by delivery per location listed by month.
 Leaves month as number.
*/


SELECT STRFTIME('%m', S.DateCreated) AS "Month",
L.Name AS "Location Name",
AVG(FuelAmountUsed) AS "Fuel Use Avg"
FROM Location AS L, Stop AS S
ON L.LocationId == S.LocationId
WHERE L.LocationId == S.LocationId
GROUP BY L.Name;
```
