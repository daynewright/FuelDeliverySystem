/*
 Selects the average fuel consumption by delivery per location listed by month.  
 Converts month to readable format.
*/

SELECT CASE STRFTIME('%m', S.DateCreated) 
	WHEN '01' THEN 'January' WHEN '02' THEN 'Febuary' WHEN '03' THEN 'March' WHEN '04' THEN 'April' WHEN '05' THEN 'May' WHEN '06' THEN 'June' 
	WHEN '07' THEN 'July' WHEN '08' THEN 'August' WHEN '09' THEN 'September' WHEN '10' THEN 'October' WHEN '11' THEN 'November' WHEN '12' THEN 'December' ELSE '' END
	AS "Month",
	L.Name AS "Location Name",
	AVG(FuelAmountUsed) AS "Fuel Use Avg"
FROM Location AS L, Stop AS S
ON L.LocationId == S.LocationId
WHERE L.LocationId == S.LocationId
GROUP BY L.Name;
