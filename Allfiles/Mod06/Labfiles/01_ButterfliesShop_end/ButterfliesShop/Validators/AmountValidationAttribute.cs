using ButterfliesShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Validators
{
    public class AmountValidationAttribute : ValidationAttribute
    {
        private int _maxAmount;
        public AmountValidationAttribute(int maxAmount)
        {
            _maxAmount = maxAmount;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Butterfly butterfly = (Butterfly)validationContext.ObjectInstance;
            //if ()
            //{
                //return new ValidationResult("");
            //}
            return ValidationResult.Success;
        }
    }
}
