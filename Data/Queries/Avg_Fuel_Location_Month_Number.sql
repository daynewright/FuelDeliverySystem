/*
 Selects the average fuel consumption by delivery per location listed by month.
 Leaves month as number.
*/


SELECT STRFTIME('%m', S.DateCreated) AS "Month",
	L.Name AS "Location Name",
	AVG(S.FuelAmountUsed) AS "Fuel Use Avg"
FROM Location AS L, Stop AS S
ON L.LocationId == S.LocationId
WHERE L.LocationId == S.LocationId
GROUP BY L.Name;
