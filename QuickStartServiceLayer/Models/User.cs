using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickStartServiceLayer.Models;

public partial class User
{
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Required(ErrorMessage = "Email is required.")]
    [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
    public string EmailId { get; set; }
    [Required(ErrorMessage = "User password is required.")]
    [StringLength(15, ErrorMessage = "User password cannot exceed 15 characters.")]
    public string UserPassword { get; set; }
    public int RoleId { get; set; }
    [Required]
    [StringLength(1, MinimumLength = 1)]
    [AllowedValues("M", "F", ErrorMessage = "Gender should be 'M' or 'F'")]
    public string Gender { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }
    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
    public string Address { get; set; }

}
