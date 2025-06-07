using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickStartServiceLayer.Models;

public partial class Product
{
    public string ProductId { get; set; }
    [Required(ErrorMessage = "Product name is required.")]
    public string ProductName { get; set; }
    [Required(ErrorMessage = "Category ID is required.")]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Price is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Quantity available is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity available must be a non-negative integer.")]
    public int QuantityAvailable { get; set; }

}
