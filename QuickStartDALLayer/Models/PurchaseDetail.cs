using System;
using System.Collections.Generic;

namespace QuickStartDALLayer.Models;

public partial class PurchaseDetail
{
    public int PurchaseId { get; set; }

    public string EmailId { get; set; }

    public string ProductId { get; set; }

    public int QuantityPurchased { get; set; }

    public DateTime DateOfPurchase { get; set; }

    public virtual User Email { get; set; }

    public virtual Product Product { get; set; }
}
