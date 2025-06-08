using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QuickStartServiceLayer.Models;

public partial class Category
{
    public int CategoryId { get; set; }
    [Required]
    [StringLength(50)]
    public string CategoryName { get; set; }
}
