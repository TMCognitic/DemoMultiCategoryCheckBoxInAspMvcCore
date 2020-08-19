CREATE PROCEDURE [dbo].[DeleteMovie]
	@Id int
AS
Begin
	Set NoCount on;
	Delete From MovieCategories where MovieId = @Id;
	Set NoCount off;

	Delete from Movie Where Id = @Id;
End
