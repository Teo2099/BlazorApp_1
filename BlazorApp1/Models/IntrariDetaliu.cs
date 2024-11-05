using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlazorApp1.Models;

namespace BlazorApp1.Models;

public partial class IntrariDetaliu
{
    public decimal Id { get; set; }

    public decimal? IdIntrari { get; set; }

    [Required]
    public decimal? Produs { get; set; }

    [Required]
    public decimal? Cantitate { get; set; }

    [Required]
    public decimal? Valoare { get; set; }

    public virtual Intrari? IdIntrariNavigation { get; set; }

    public virtual Produse? ProdusNavigation { get; set; }
}
