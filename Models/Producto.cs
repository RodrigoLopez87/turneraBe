using System;
using System.Collections.Generic;

namespace turnera.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ImgUrl { get; set; }

    public int? Price { get; set; }

    public int? MarcaId { get; set; }

    public virtual Marca? Marca { get; set; }
}
