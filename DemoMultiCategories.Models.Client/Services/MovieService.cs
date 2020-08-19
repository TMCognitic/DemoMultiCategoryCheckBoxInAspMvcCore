using DemoMultiCategories.Models.Client.Data;
using DemoMultiCategories.Models.Client.Interfaces;
using DemoMultiCategories.Models.Client.Mappers;
using GD = DemoMultiCategories.Models.Global.Data;
using GI = DemoMultiCategories.Models.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tools.Databases;


namespace DemoMultiCategories.Models.Client.Services
{
    public class MovieService : IMovieRepository
    {
        private readonly GI.IMovieRepository _movieRepository;

        public MovieService(GI.IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }        

        public IEnumerable<Movie> Get()
        {
            return _movieRepository.Get().Select(m => m.ToClient());
        }

        public Movie Get(int id)
        {
            return _movieRepository.Get(id)?.ToClient();
        }

        public void Insert(Movie movie, IEnumerable<int> categories)
        {
            _movieRepository.Insert(movie.ToGlobal(), categories);
        }

        public void Update(int id, Movie movie, IEnumerable<int> categories)
        {
            GD.Movie globalMovie = movie.ToGlobal();
            globalMovie.Id = id;

            _movieRepository.Update(globalMovie, categories);
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }
    }
}
