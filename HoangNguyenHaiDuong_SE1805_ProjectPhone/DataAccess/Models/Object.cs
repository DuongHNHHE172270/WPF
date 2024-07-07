using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Object
{
    public string Id { get; set; } = null!;

    public string? DisplayName { get; set; }

    public int IdSuplier { get; set; }

    public string? Status { get; set; }

    public virtual Suplier IdSuplierNavigation { get; set; } = null!;

    public virtual ICollection<InputInfo> InputInfos { get; set; } = new List<InputInfo>();

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
