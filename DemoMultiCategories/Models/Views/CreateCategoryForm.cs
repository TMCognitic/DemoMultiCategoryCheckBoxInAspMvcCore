﻿using DemoMultiCategories.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMultiCategories.Models.Views
{
    
    public class CreateCategoryForm
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [UniqueValidation(ValidationAction.Insert)]
        public string Name { get; set; }
    }
}
