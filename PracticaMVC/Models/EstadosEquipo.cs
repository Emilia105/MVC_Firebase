using System;
using System.Collections.Generic;

namespace PracticaMVC.Models;

public partial class EstadosEquipo
{
    public int IdEstadosEquipo { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
