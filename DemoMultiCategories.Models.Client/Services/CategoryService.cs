using DemoMultiCategories.Models.Client.Data;
using DemoMultiCategories.Models.Client.Interfaces;
using GI = DemoMultiCategories.Models.Global.Interfaces;
using GD = DemoMultiCategories.Models.Global.Data;
using DemoMultiCategories.Models.Client.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoMultiCategories.Models.Client.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly GI.ICategoryRepository _categoryRepository;

        public CategoryService(GI.ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Get()
        {
            return _categoryRepository.Get().Select(c => c.ToClient());
        }

        public IEnumerable<Category> GetByMovieId(int movieId)
        {
            return _categoryRepository.GetByMovieId(movieId).Select(c => c.ToClient());
        }

        public Category Get(int id)
        {
            return _categoryRepository.Get(id)?.ToClient();
        }

        public void Insert(Category category)
        {            
            _categoryRepository.Insert(category.ToGlobal());
        }

        public void Update(int id, Category category)
        {
            GD.Category globalCatagory = category.ToGlobal();
            globalCatagory.Id = id;
            _categoryRepository.Update(globalCatagory);
        }
    }
}
