using System;
using System.Collections.Generic;

namespace TrailSystem.Models;

public partial class User
{
    internal object name;

    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}
