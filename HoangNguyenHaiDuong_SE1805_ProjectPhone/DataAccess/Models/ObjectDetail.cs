using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ObjectDetail
{
    public int Id { get; set; }

    public int IdObject { get; set; }

    public string? Capacity { get; set; }

    public int Count { get; set; }

    public virtual Object IdObjectNavigation { get; set; } = null!;
}
