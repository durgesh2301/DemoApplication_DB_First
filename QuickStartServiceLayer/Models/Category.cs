using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuickStartServiceLayer.Models;

public partial class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
