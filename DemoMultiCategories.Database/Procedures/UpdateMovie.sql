CREATE PROCEDURE [dbo].[UpdateMovie]
	@Id int,
	@Title nvarchar(255),
	@Year int,
	@Categories CategoryArray readonly
AS
Begin
	Set NoCount On;
	Delete from MovieCategories Where MovieId = @Id;
	Insert Into MovieCategories (MovieId, CategoryId) Select @Id, CategoryId From @Categories;
	Set NoCount Off;

	Update Movie set Title = @Title, Year = @Year Where Id = @Id;
End