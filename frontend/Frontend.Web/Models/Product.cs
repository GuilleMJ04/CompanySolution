using System.ComponentModel.DataAnnotations;

namespace Frontend.Web.Models;

public class Product
{
    public int ProductID { get; set; }

    [Display(Name = "Product name")]
    [Required(ErrorMessage = "{0} Must Be Filled In.")]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Category { get; set; } = string.Empty;

    [Display(Name = "Unit price")]
    [Range(0.0, double.MaxValue, ErrorMessage = "Unit price cannot be negative.")]
    public decimal UnitPrice { get; set; }

    [Display(Name = "Units in stock")]
    [Range(0, int.MaxValue)]
    public int UnitsInStock { get; set; }

    public bool Discontinued { get; set; }
}