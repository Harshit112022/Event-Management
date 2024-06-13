CREATE OR ALTER PROCEDURE TasksGetList
/*
***********************************************************************************************
	Date   			Created By   			Purpose of Modification
1	10JUNE2024		Harshit Chilvirwar		Get List for Tasks
***********************************************************************************************
execute TasksGetList

select * from Tasks
*/

AS
BEGIN

	SELECT 	
		ISNULL(TaskId, '') AS TaskId,
		ISNULL(TaskName, '') AS TaskName
	FROM
		Tasks
	WHERE OtherTasks=0;	
END
