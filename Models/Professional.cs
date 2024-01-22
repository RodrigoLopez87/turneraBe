using System;
using System.Collections.Generic;

namespace turnera.Models;

public partial class Professional
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string AvailableTimes { get; set; } = null!;
}
