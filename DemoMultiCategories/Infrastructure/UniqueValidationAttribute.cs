using DemoMultiCategories.Models.Client.Interfaces;
using DemoMultiCategories.Models.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoMultiCategories.Infrastructure
{
    public class UniqueValidationAttribute : ValidationAttribute
    {
        private readonly ValidationAction action;

        public UniqueValidationAttribute(ValidationAction action)
        {
            this.action = action;
            ErrorMessage = "La valeur existe déjà...";            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ICategoryRepository categoryRepository = validationContext.GetService<ICategoryRepository>();

            if(action == ValidationAction.Insert)
            {
                if (categoryRepository.Exists((string)value))
                {
                    return new ValidationResult(ErrorMessage);
                }                
            }
            else
            {
                UpdateCategoryForm updateCategoryForm = (UpdateCategoryForm)validationContext.ObjectInstance;
                if (categoryRepository.Exists(updateCategoryForm.Id, (string)value))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
