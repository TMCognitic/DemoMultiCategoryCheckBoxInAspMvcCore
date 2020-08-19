using DemoMultiCategories.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace DemoMultiCategories.Models.Views
{
    public class DisplayMovie
    {
        private readonly Movie _movie;
        IEnumerable<string> _categories;

        public DisplayMovie(Movie movie, IEnumerable<Category> categories)
        {
            _movie = movie;
            _categories = categories.Select(c => c.Name);
        }

        public int Id
        {
            get 
            {
                return _movie.Id;
            }
        }

        public string Title
        {
            get
            {
                return _movie.Title;
            }
        }

        public int Year
        {
            get
            {
                return _movie.Year;
            }
        }

        public IEnumerable<string> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}
