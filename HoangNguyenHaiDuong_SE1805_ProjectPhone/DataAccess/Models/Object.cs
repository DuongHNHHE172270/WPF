using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Object
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public int IdSuplier { get; set; }

    public string? Status { get; set; }

    public virtual Suplier IdSuplierNavigation { get; set; } = null!;

    public virtual ICollection<InputInfo> InputInfos { get; set; } = new List<InputInfo>();

    public virtual ICollection<ObjectDetail> ObjectDetails { get; set; } = new List<ObjectDetail>();

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
