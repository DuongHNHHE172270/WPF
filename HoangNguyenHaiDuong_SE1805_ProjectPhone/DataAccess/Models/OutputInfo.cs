using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class OutputInfo
{
    public int Id { get; set; }

    public int IdObject { get; set; }

    public int IdOutput { get; set; }

    public int IdCustomer { get; set; }

    public int? Count { get; set; }

    public string? Status { get; set; }

    public int? IdUser { get; set; }

    public string Capacity { get; set; } = null!;

    public virtual ICollection<BillHistory> BillHistories { get; set; } = new List<BillHistory>();

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual Object IdObjectNavigation { get; set; } = null!;

    public virtual Output IdOutputNavigation { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }
}
