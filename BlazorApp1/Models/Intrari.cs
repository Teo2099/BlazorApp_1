using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlazorApp1.Data.Entities;

namespace BlazorApp1.Models;

public partial class Intrari
{
    public decimal Id { get; set; }

    public decimal Numar { get; set; }

    [Required]
    public DateTime? Data { get; set; }

    [Required]
    public decimal? Partener { get; set; }
    [Required]
    public decimal? Gestiune { get; set; }

    public virtual Gestiuni? GestiuneNavigation { get; set; }

    public virtual ICollection<IntrariDetaliu> IntrariDetalius { get; set; } = new List<IntrariDetaliu>();

    public virtual Parteneri? PartenerNavigation { get; set; }
}
