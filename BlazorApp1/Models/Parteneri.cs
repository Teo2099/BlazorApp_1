using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models;

public partial class Parteneri
{
    public decimal Id { get; set; }

    public int Cod { get; set; }

    [Required]
    public string? Denumire { get; set; }

    [Required]
    public string? Cui { get; set; }

    [Required]
    public string? Adresa { get; set; }

    public virtual ICollection<Intrari> Intraris { get; set; } = new List<Intrari>();
}
