using System;
using System.Collections.Generic;

namespace RentCard.Models.BD;

public partial class Cliente
{
    public int Cedula { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono1 { get; set; } = null!;

    public string? Telefono2 { get; set; }

    public virtual ICollection<Alquiler> Alquilers { get; set; } = new List<Alquiler>();
}
