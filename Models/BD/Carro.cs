using System;
using System.Collections.Generic;

namespace RentCard.Models.BD;

public partial class Carro
{
    public string Placa { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public decimal Costo { get; set; }

    public string Disponible { get; set; } = null!;

    public virtual ICollection<Alquiler> Alquilers { get; set; } = new List<Alquiler>();
}
