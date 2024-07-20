using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class InputInfo
{
    public int Id { get; set; }

    public int IdObject { get; set; }

    public int IdInput { get; set; }

    public int Count { get; set; }

    public double? InputPrice { get; set; }

    public int IdUser { get; set; }

    public string? Status { get; set; }

    public string Capacity { get; set; } = null!;

    public virtual Input IdInputNavigation { get; set; } = null!;

    public virtual Object IdObjectNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
