using System;
using System.Collections.Generic;

namespace DALLayer.Models;

public partial class CardDetail
{
    public decimal CardNumber { get; set; }

    public string NameOnCard { get; set; }

    public string CardType { get; set; }

    public int Cvvnumber { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public decimal Balance { get; set; }
}
