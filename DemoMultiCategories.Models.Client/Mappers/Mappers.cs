using DemoMultiCategories.Models.Client.Data;
using G = DemoMultiCategories.Models.Global.Data;

namespace DemoMultiCategories.Models.Client.Mappers
{
    internal static class Mappers
    {
        #region Category Mappers
        internal static Category ToClient(this G.Category category)
        {
            return new Category(category.Id, category.Name);
        }

        internal static G.Category ToGlobal(this Category category)
        {
            return new G.Category() { Id = category.Id, Name = category.Name };
        }
        #endregion

        #region Movie Mappers
        internal static Movie ToClient(this G.Movie movie)
        {
            return new Movie(movie.Id, movie.Title, movie.Year);
        }

        internal static G.Movie ToGlobal(this Movie movie)
        {
            return new G.Movie() { Id = movie.Id, Title = movie.Title, Year = movie.Year };
        }
        #endregion
    }
}
