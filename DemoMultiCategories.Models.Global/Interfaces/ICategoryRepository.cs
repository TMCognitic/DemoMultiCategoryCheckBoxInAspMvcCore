using DemoMultiCategories.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMultiCategories.Models.Global.Interfaces
{
    public interface ICategoryRepository
    {
        bool Exists(string categoryName);
        bool Exists(int id, string categoryName);
        IEnumerable<Category> Get();
        IEnumerable<Category> GetByMovieId(int movieId);
        Category Get(int id);
        void Insert(Category category);
        void Update(Category category);
    }
}
