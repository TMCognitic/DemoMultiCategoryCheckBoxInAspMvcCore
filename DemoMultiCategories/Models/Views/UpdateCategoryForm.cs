using DemoMultiCategories.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMultiCategories.Models.Views
{
    public class UpdateCategoryForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [UniqueValidation(ValidationAction.Update)]
        public string Name { get; set; }
    }
}
