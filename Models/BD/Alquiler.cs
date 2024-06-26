using System;
using System.Collections.Generic;

namespace RentCard.Models.BD;

public partial class Alquiler
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int Tiempo { get; set; }

    public decimal ValorTotal { get; set; }

    public decimal Saldo { get; set; }

    public decimal AbonoInicial { get; set; }

    public string Devuelto { get; set; } = null!;

    public string PlacaCarro { get; set; } = null!;

    public int CedulaCliente { get; set; }

    public virtual Cliente CedulaClienteNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Carro PlacaCarroNavigation { get; set; } = null!;
}
