using System;
using System.Collections.Generic;

namespace PracticaMVC.Models;

public partial class Marca
{
    public int IdMarcas { get; set; }

    public string? NombreMarca { get; set; }

    public string? Estados { get; set; }

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();

    
}
