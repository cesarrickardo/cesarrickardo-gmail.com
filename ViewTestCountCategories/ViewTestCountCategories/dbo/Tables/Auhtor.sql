CREATE TABLE [dbo].[Auhtor] (
    [AuthorID]    INT           IDENTITY (1, 1) NOT NULL,
    [Author Name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Auhtor] PRIMARY KEY CLUSTERED ([AuthorID] ASC)
);

