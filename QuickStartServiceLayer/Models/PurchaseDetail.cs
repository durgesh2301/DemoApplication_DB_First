using System;
using System.Collections.Generic;

namespace QuickStartServiceLayer.Models;

public partial class PurchaseDetail
{
    public int PurchaseId { get; set; }

    public string EmailId { get; set; }

    public string ProductId { get; set; }

    public int QuantityPurchased { get; set; }

    public DateTime DateOfPurchase { get; set; }
}
