using System;
using System.Collections.Generic;

namespace TrailSystem.Models;

public partial class Trail
{
    public int TrailId { get; set; }

    public string? Name { get; set; }

    public double? Distance { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
