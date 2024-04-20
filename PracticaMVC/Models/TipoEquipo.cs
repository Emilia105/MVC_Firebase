using System;
using System.Collections.Generic;

namespace PracticaMVC.Models;

public partial class TipoEquipo
{
    public int IdTipoEquipo { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
