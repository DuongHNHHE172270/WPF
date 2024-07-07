using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class InputInfo
{
    public string Id { get; set; } = null!;

    public string IdObject { get; set; } = null!;

    public string IdInput { get; set; } = null!;

    public int? Count { get; set; }

    public double? InputPrice { get; set; }

    public double? OutputPrice { get; set; }

    public int IdUser { get; set; }

    public virtual Input IdInputNavigation { get; set; } = null!;

    public virtual Object IdObjectNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
