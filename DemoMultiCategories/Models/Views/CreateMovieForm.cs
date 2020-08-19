using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMultiCategories.Models.Forms
{
    public class CreateMovieForm
    {
        [Required]
        [StringLength(255, MinimumLength=2)]
        public string Title { get; set; }
        [Required]
        [Range(1930, 9999)]
        public int Year { get; set; }
        public IList<SelectListItem> Categories { get; set; }
    }
}
