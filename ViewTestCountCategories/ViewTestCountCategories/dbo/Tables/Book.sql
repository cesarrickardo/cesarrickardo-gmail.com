CREATE TABLE [dbo].[Book] (
    [BookID] INT           IDENTITY (1, 1) NOT NULL,
    [Books]  NVARCHAR (50) NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([BookID] ASC)
);

