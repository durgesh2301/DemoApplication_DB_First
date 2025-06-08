using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickStartServiceLayer.Models;

public partial class CardDetail
{
    [Required]
    [Range(1000000000000000, 9999999999999999, ErrorMessage = "Card number must be a 16-digit number.")]
    public decimal CardNumber { get; set; }
    [Required]
    [StringLength(50)]
    public string NameOnCard { get; set; }
    [Required]
    [StringLength(1, MinimumLength = 1)]
    [AllowedValues("V","M","A",ErrorMessage = "Card Type should be 'V', 'M' or 'A'")]
    public string CardType { get; set; }
    [Required]
    [Range(100, 999)]
    public int Cvvnumber { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateOnly ExpiryDate { get; set; }
    [Required]
    [Range(0,int.MaxValue)]
    public decimal Balance { get; set; }
}
