using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAnnotationsExample.Models;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExample.Validators
{
    public class AgeValidationAttribute : ValidationAttribute
    {
        private int _minYear;
        public AgeValidationAttribute(int minYear)
        {
            _minYear = minYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Person person = (Person)validationContext.ObjectInstance;
            if (person.Birthdate.Year > _minYear)
            {
                return new ValidationResult("Sorry you should be at least 18 years old to submit your personal information");
            }
            return ValidationResult.Success;
        }
    }
}
