using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
