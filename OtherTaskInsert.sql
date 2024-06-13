CREATE OR ALTER PROCEDURE OtherTaskInsert 
@TaskName VARCHAR(MAX),
@lastIdentity INT OUT
/*
select * from Tasks
DELETE FROM Tasks WHERE TaskId>6;
***********************************************************************************************
	Date   			Modified By   		Purpose of Modification
1	11JUNE2024		Harshit Chilvirwar	Insert OtherTask
***********************************************************************************************
DECLARE @VAR INT
EXECUTE OtherTaskInsert null,@VAR OUT
PRINT @VAR
*/
AS
BEGIN


	INSERT INTO Tasks
	(
		TaskName,
		OtherTasks,
		IsActive,
		CreatedBy,
		CreatedOn
	)
	VALUES
	(
		@TaskName,
		1,
		1,
		'admin',
		GETDATE()		
	)
	SET @lastIdentity = IDENT_CURRENT ('Tasks');
END
