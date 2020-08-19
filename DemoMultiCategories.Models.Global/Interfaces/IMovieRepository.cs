using DemoMultiCategories.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMultiCategories.Models.Global.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        Movie Get(int id);
        void Insert(Movie movie, IEnumerable<int> categories);
        void Update(Movie movie, IEnumerable<int> categories);
        void Delete(int id);
    }
}
