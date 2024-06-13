CREATE TABLE EventLocations
(
EventLocationId INT PRIMARY KEY IDENTITY(1,1),
EventLocation VARCHAR (MAX),
IsActive BIT,
CreatedBy VARCHAR(MAX),
CreatedOn DATETIME,
ModifiedBy VARCHAR(MAX),
ModifiedOn DATETIME
)
Go
INSERT INTO EventLocations(EventLocation,IsActive,CreatedBy,CreatedOn)VALUES 
('Mumbai',1,'admin',GETDATE()),
('Delhi',1,'admin',GETDATE()),
('Pune',1,'admin',GETDATE());

CREATE TABLE EventTypes
(
EventTypesId INT PRIMARY KEY IDENTITY(1,1),
EventType VARCHAR (200),
IsActive BIT,
CreatedBy VARCHAR(max),
CreatedOn DATETIME,
ModifiedBy INT,
ModifiedOn DATETIME
)

Go

INSERT INTO EventTypes (EventType,IsActive,CreatedBy,CreatedOn)VALUES
('Engagement',1,'admin',GETDATE()),
('Birthday',1,'admin',GETDATE()),
('Anniversary',1,'admin',GETDATE());

CREATE TABLE [Events]
(
EventId INT PRIMARY KEY IDENTITY(1,1),
EventName VARCHAR (MAX),
EventLocationId INT,
EventTypesId INT,
EventDate DATE,
EventTime TIME,
FOREIGN KEY (EventTypesId) REFERENCES EventTypes(EventTypesId),
FOREIGN KEY (EventLocationId) REFERENCES EventLocations(EventLocationId),
IsActive BIT,
CreatedBy VARCHAR(MAX),
CreatedOn DATETIME,
ModifiedBy VARCHAR(MAX),
ModifiedOn DATETIME
)
Go


CREATE TABLE Tasks
(
TaskId INT PRIMARY KEY IDENTITY(1,1),
TaskName VARCHAR (MAX),
OtherTasks BIT,
IsActive BIT,
CreatedBy VARCHAR(MAX),
CreatedOn DATETIME,
ModifiedBy VARCHAR(MAX),
ModifiedOn DATETIME,
)

Go


CREATE TABLE EventTasks
(
EventTaskId INT PRIMARY KEY IDENTITY(1,1),
EventId INT,
TaskId INT,
FOREIGN KEY (EventId) REFERENCES [Events](EventId),
FOREIGN KEY (TaskId) REFERENCES [Tasks](TaskId),
IsActive BIT,
CreatedBy VARCHAR(MAX),
CreatedOn DATETIME,
ModifiedBy VARCHAR(MAX),
ModifiedOn DATETIME,
)
Go

SELECT * FROM [Events]
SELECT * FROM EventLocations
SELECT * FROM EventTypes
SELECT * FROM Tasks
SELECT * FROM EventTasks

