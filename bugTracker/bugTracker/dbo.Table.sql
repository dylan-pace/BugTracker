CREATE TABLE [dbo].[Table]
(
	[Bug_ID] INT NOT NULL PRIMARY KEY, 
    [Logger_Name] TEXT NOT NULL, 
    [Date_Logged] DATE NOT NULL, 
    [Class_Name] TEXT NOT NULL, 
    [Method_Name] TEXT NOT NULL, 
    [Line_Start] INT NOT NULL, 
    [Line_End] INT NOT NULL
)
