CREATE OR ALTER PROCEDURE EventLocationsGetList

/*
***********************************************************************************************
	Date   			Created By   			Purpose of Modification
1	10JUNE2024		Harshit Chilvirwar		Get List for EventLocation
***********************************************************************************************
execute EventLocationsGetList
select * from EventLocations

*/

AS
BEGIN

	SELECT 
		ISNULL(EventLocationId, '') AS EventLocationId,
		ISNULL(EventLocation, '') AS EventLocation
	
	FROM
		EventLocations;	
END
