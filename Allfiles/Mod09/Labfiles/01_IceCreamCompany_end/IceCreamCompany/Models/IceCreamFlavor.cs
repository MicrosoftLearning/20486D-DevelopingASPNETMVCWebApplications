using System.ComponentModel.DataAnnotations;

namespace IceCreamCompany.Models
{
    public enum IceCreamFlavor
    {
        [Display(Name = "Vanilla Ice Cream with Caramel Ripple and Almonds")]
        VanillaIceCream1,

        [Display(Name = "Vanilla Ice Cream with Cherry Dark Chocolate Ice Cream")]
        VanillaIceCream2,

        [Display(Name = "Vanilla Ice Cream with Pistachio")]
        VanillaIceCream3,
    }
}