using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlazorApp1.Data.Entities;

namespace BlazorApp1.Models;

public partial class Iesiri
{
    public decimal Id { get; set; }

    public decimal? Numar { get; set; }

    [Required]
    public DateTime? Data { get; set; }

    [Required]
    public decimal? Gestiunea { get; set; }

    public virtual Gestiuni? GestiuneaNavigation { get; set; }

    public virtual ICollection<IesiriDetaliu> IesiriDetalius { get; set; } = new List<IesiriDetaliu>();
}
