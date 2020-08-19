using DemoMultiCategories.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMultiCategories.Models.Client.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        IEnumerable<Category> GetByMovieId(int movieId);
        Category Get(int id);
        void Insert(Category category);
        void Update(int id, Category category);
    }
}
