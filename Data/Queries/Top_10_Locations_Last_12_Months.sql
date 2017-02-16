SELECT L.Name AS "Location Name",
SUM(FuelAmountUsed) AS "Fuel Received"
FROM Location AS L INNER JOIN Stop AS S
ON L.LocationId == S.LocationId
WHERE S.DateCreated BETWEEN DATE('now', 'start of month', '-11 months') AND DATE('now')
GROUP BY L.Name
ORDER BY "Fuel Received" DESC
LIMIT 10;