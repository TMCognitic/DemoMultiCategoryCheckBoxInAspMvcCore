CREATE TABLE [dbo].[MovieCategories]
(
	[MovieId] INT NOT NULL,
	[CategoryId] INT NOT NULL, 
    CONSTRAINT [PK_MovieCategories] PRIMARY KEY ([MovieId], [CategoryId])
)
