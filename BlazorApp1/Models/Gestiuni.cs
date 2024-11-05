using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BlazorApp1.Models;

public partial class Gestiuni
{
    public decimal Id { get; set; }

    public int Cod { get; set; }

    [Required]
    public string? Denumire { get; set; }

    public virtual ICollection<Iesiri> Iesiris { get; set; } = new List<Iesiri>();

    public virtual ICollection<Intrari> Intraris { get; set; } = new List<Intrari>();
}
