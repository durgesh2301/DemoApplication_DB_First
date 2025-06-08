using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuickStartServiceLayer.Models;

public partial class PurchaseDetail
{
    public int PurchaseId { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
    public string EmailId { get; set; }
    [Required]
    [StringLength(4, MinimumLength = 4)]
    public string ProductId { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity purchased must be greater than zero.")]
    public int QuantityPurchased { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfPurchase { get; set; }
}
