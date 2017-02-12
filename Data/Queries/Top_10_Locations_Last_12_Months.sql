# Selects the top 10 locations in the last 12 months that received fuel deliveries.  
# Lists them descending by fuel delivery total.

SELECT L.Name AS "Location Name",
	(SELECT SUM(FuelAmountUsed)
	 FROM Stop AS S
	 WHERE S.LocationId == L.LocationId) AS "Fuel Received"
FROM Location AS L INNER JOIN Stop AS S
WHERE S.DateCreated BETWEEN DATE('now', 'start of month', '-11 months') AND DATE('now')
GROUP BY L.Name
ORDER BY "Fuel Received" DESC
LIMIT 10;