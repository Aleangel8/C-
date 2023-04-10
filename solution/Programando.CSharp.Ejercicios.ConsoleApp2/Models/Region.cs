using System;
using System.Collections.Generic;

namespace Programando.CSharp.Ejercicios.ConsoleApp2.Models;

public partial class Region
{
    public int RegionID { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; } = new List<Territory>();
}
