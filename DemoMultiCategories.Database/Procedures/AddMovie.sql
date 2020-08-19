CREATE PROCEDURE [dbo].[AddMovie]
	@Title nvarchar(255),
	@Year int,
	@Categories CategoryArray readonly
AS
Begin
	Insert into Movie (Title, Year) values (@Title, @Year);
	Declare @Id int = Scope_Identity();

	Set NoCount On;
	insert into MovieCategories (MovieId, CategoryId)
	Select @Id, IdCategory from @Categories;
End

