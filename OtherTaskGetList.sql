CREATE OR ALTER  PROCEDURE OtherTaskGetList

/*
***********************************************************************************************
	Date   			Created By   		Purpose of Modification
1	11jun2024		Harshit Chilvirwar		Get List for Other Task
***********************************************************************************************
OtherTaskGetList
select * from Tasks WHERE OtherTasks =1
insert into Tasks (TaskName,OtherTasks,IsActive,CreatedBy,CreatedOn)
values('shoping',1,1,'admin',getdate())

*/

AS
BEGIN

	SELECT 
		ISNULL(TaskId, '') AS TaskId,
		ISNULL(TaskName, '') AS TaskName
	FROM
		Tasks
	WHERE OtherTasks =1 ;	
	
	

	
END


GO