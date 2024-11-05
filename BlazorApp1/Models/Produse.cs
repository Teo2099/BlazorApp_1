using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlazorApp1.Data.Entities;

namespace BlazorApp1.Models;

public partial class Produse
{
    public decimal Id { get; set; }

    public int Cod { get; set; }

    [Required]
    public string? Denumire { get; set; }

    [Required]
    public decimal? PretUnitar { get; set; }

    public virtual ICollection<IesiriDetaliu> IesiriDetalius { get; set; } = new List<IesiriDetaliu>();

    public virtual ICollection<IntrariDetaliu> IntrariDetalius { get; set; } = new List<IntrariDetaliu>();
}
