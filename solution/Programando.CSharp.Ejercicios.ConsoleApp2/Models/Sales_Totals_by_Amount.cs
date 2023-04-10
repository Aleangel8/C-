using System;
using System.Collections.Generic;

namespace Programando.CSharp.Ejercicios.ConsoleApp2.Models;

public partial class Sales_Totals_by_Amount
{
    public decimal? SaleAmount { get; set; }

    public int OrderID { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }
}
