using DemoMultiCategories.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMultiCategories.Models.Client.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        Movie Get(int id);
        void Insert(Movie movie, IEnumerable<int> categories);
        void Update(int id, Movie movie, IEnumerable<int> categories);
        void Delete(int id);
    }
}
