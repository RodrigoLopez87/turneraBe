using System;
using System.Collections.Generic;

namespace turnera.Models;

public partial class Entity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LogoUrl { get; set; } = null!;

    public string MainPageMessage { get; set; } = null!;

    public string UrlIdentifier { get; set; } = null!;
}
