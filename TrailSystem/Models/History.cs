using System;
using System.Collections.Generic;

namespace TrailSystem.Models;

public partial class History
{
    public int TrailHistory { get; set; }

    public string? Name { get; set; }

    public double? Distance { get; set; }

    public int? ProfileId { get; set; }

    public int? TrailId { get; set; }

    public virtual Profile? Profile { get; set; }

    public virtual Trail? Trail { get; set; }
}
