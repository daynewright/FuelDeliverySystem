/*
 Selects the average fuel consumption by delivery per location listed by month.
 Leaves month as number.
*/


SELECT STRFTIME('%m', S.DateCreated) AS "Month",
	L.Name AS "Location Name",
	(SELECT AVG(FuelAmountUsed)
	 FROM Stop AS S
	 WHERE S.LocationId == L.LocationId) AS "Fuel Use Avg"
FROM Location AS L, Stop AS S
WHERE L.LocationId == S.LocationId
GROUP BY L.Name;
