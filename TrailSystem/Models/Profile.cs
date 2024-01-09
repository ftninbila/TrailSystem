using System;
using System.Collections.Generic;

namespace TrailSystem.Models;

public partial class Profile
{
    public int ProfileId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual User? User { get; set; }
}
