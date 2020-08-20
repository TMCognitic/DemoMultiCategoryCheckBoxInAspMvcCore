using DemoMultiCategories.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMultiCategories.Models.Client.Interfaces
{
    public interface ICategoryRepository
    {
        bool Exists(string categoryName);
        bool Exists(int id, string categoryName);
        IEnumerable<Category> Get();
        IEnumerable<Category> GetByMovieId(int movieId);
        Category Get(int id);
        void Insert(Category category);
        void Update(int id, Category category);
    }
}
