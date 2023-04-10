using System;
using System.Collections.Generic;

namespace Programando.CSharp.Ejercicios.ConsoleApp2.Models;

public partial class CustomerDemographic
{
    public string CustomerTypeID { get; set; } = null!;

    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
