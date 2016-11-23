CREATE TABLE [dbo].[BookShop] (
    [BookShopID] INT IDENTITY (1, 1) NOT NULL,
    [AutherID]   INT NOT NULL,
    [BookID]     INT NOT NULL,
    CONSTRAINT [PK_BookShop] PRIMARY KEY CLUSTERED ([BookShopID] ASC),
    CONSTRAINT [FK_BookShop_Auhtor] FOREIGN KEY ([AutherID]) REFERENCES [dbo].[Auhtor] ([AuthorID]),
    CONSTRAINT [FK_BookShop_Book] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Book] ([BookID])
);

