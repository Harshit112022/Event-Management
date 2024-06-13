CREATE OR ALTER PROCEDURE EventTypesGetList
/*
***********************************************************************************************
	Date   			Created By   			Purpose of Modification
1	10JUNE2024		Harshit Chilvirwar		Get List for EventTypes
***********************************************************************************************
execute EventTypesGetList

select * from EventTypes
*/

AS
BEGIN

	SELECT 
		ISNULL(EventTypesId, '') AS EventTypesId,
		ISNULL(EventType, '') AS EventType
	
	FROM
		EventTypes;	
END
