using System;
using System.Collections.Generic;

namespace RentCard.Models.BD;

public partial class Pago
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Valor { get; set; }

    public int AlquilerId { get; set; }

    public virtual Alquiler Alquiler { get; set; } = null!;
}
