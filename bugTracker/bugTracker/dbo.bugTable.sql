CREATE TABLE [dbo].[bugTable] (
    [Bug_ID]      INT  IDENTITY (1, 1) NOT NULL,
    [Description] TEXT NOT NULL,
    [Logger_Name] TEXT NOT NULL,
    [Date_Logged] TEXT NOT NULL,
    [Class_Name]  TEXT NOT NULL,
    [Method_Name] TEXT NOT NULL,
    [Line_Start]  INT  NOT NULL,
    [Line_End]    INT  NOT NULL,
    [File_Name] TEXT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Bug_ID] ASC)
);

