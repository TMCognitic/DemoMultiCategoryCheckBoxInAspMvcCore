CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL IDENTITY, 
    [Title] NVARCHAR(255) NOT NULL, 
    [Year] INT NOT NULL, 
    CONSTRAINT [PK_Movie] PRIMARY KEY ([Id]), 
    CONSTRAINT [CK_Movie_Year] CHECK (Year > 1900)
)
