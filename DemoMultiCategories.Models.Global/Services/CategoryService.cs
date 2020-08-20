using DemoMultiCategories.Models.Global.Data;
using DemoMultiCategories.Models.Global.Interfaces;
using DemoMultiCategories.Models.Global.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Databases;

namespace DemoMultiCategories.Models.Global.Services
{
    public class CategoryService : ICategoryRepository
    {
        private IConnection _connection;

        public CategoryService(IConnection connection)
        {
            _connection = connection;
        }

        public bool Exists(string categoryName)
        {
            Command command = new Command("Select count(*) from Category where Name = @Name;");
            command.AddParameter("Name", categoryName);
            return ((int)_connection.ExecuteScalar(command)) == 1;
        }

        public bool Exists(int id, string categoryName)
        {
            Command command = new Command("Select count(*) from Category where Name = @Name and id <> @id;");
            command.AddParameter("Name", categoryName);
            command.AddParameter("Id", id);
            return ((int)_connection.ExecuteScalar(command)) == 1;
        }

        public IEnumerable<Category> Get()
        {
            Command command = new Command("Select Id, Name from Category;");
            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }

        public IEnumerable<Category> GetByMovieId(int movieId)
        {
            Command command = new Command("Select Id, Name from Category C Join MovieCategories MC on C.Id = MC.CategoryId where MovieId = @MovieId;");
            command.AddParameter("MovieId", movieId);
            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }

        public Category Get(int id)
        {
            Command command = new Command("Select Id, Name from Category Where Id = @Id;");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToCategory()).SingleOrDefault();
        }

        public void Insert(Category category)
        {
            Command command = new Command("Insert into Category (Name) values (@Name);");
            command.AddParameter("Name", category.Name);
            _connection.ExecuteNonQuery(command);
        }

        public void Update(Category category)
        {
            Command command = new Command("Update Category set Name = @Name Where Id = @Id;");
            command.AddParameter("Name", category.Name);
            command.AddParameter("Id", category.Id);
            _connection.ExecuteNonQuery(command);
        }
    }
}
