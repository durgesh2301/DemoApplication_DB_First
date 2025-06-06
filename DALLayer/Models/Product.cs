using System;
using System.Collections.Generic;

namespace DALLayer.Models;

public partial class Product
{
    public string ProductId { get; set; }

    public string ProductName { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int QuantityAvailable { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
