using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterfliesShop.Models;
using ButterfliesShop.Services;
using System.ComponentModel.DataAnnotations;

namespace ButterfliesShop.Validators
{
    public class MaxButterflyQuantityValidation : ValidationAttribute
    {
        private int _maxAmount;
        public MaxButterflyQuantityValidation(int maxAmount)
        {
            _maxAmount = maxAmount;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IButterfliesQuantityService)validationContext.GetService(typeof(IButterfliesQuantityService));
            Butterfly butterfly = (Butterfly)validationContext.ObjectInstance;
            if (butterfly.ButterflyFamily != null)
            {
                int? quantity = service.GetButterflyFamilyQuantity(butterfly.ButterflyFamily.Value);
                int? sumQuantity = quantity + butterfly.Quantity;
                if (sumQuantity > _maxAmount)
                {
                    return new ValidationResult(string.Format("Limit of butterflies from the same family in the store is {0} butterflies. Currently there are {1}", _maxAmount, quantity));
                }
                return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }
}
