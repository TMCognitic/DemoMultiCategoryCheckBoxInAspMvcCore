using DemoMultiCategories.Models.Global.Data;
using DemoMultiCategories.Models.Global.Interfaces;
using DemoMultiCategories.Models.Global.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tools.Databases;

namespace DemoMultiCategories.Models.Global.Services
{
    public class MovieService : IMovieRepository
    {
        private IConnection _connection;

        public MovieService(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Movie> Get()
        {
            Command command = new Command("Select Id, Title, Year from Movie;");
            return _connection.ExecuteReader(command, dr => dr.ToMovie());
        }

        public Movie Get(int id)
        {
            Command command = new Command("Select Id, Title, Year from Movie Where Id = @Id;");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToMovie()).SingleOrDefault();
        }

        public void Insert(Movie movie, IEnumerable<int> categories)
        {
            if (movie is null)
                throw new ArgumentNullException(nameof(movie));

            if (categories is null)
                throw new ArgumentNullException(nameof(categories));

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IdCategory", typeof(int));

            foreach (int categoryId in categories)
                dataTable.Rows.Add(categoryId);

            Command command = new Command("AddMovie", true);
            command.AddParameter("Title", movie.Title);
            command.AddParameter("Year", movie.Year);            
            command.AddParameter("Categories", dataTable);

            _connection.ExecuteNonQuery(command);
        }

        public void Update(Movie movie, IEnumerable<int> categories)
        {
            if (movie is null)
                throw new ArgumentNullException(nameof(movie));

            if (categories is null)
                throw new ArgumentNullException(nameof(categories));

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IdCategory", typeof(int));

            foreach (int categoryId in categories)
                dataTable.Rows.Add(categoryId);

            Command command = new Command("UpdateMovie", true);
            command.AddParameter("Id", movie.Id);
            command.AddParameter("Title", movie.Title);
            command.AddParameter("Year", movie.Year);
            command.AddParameter("Categories", dataTable);

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("DeleteMovie", true);
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }
    }
}
