using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class BillHistory
{
    public int Id { get; set; }

    public int IdOutputInfo { get; set; }

    public int IdCustomer { get; set; }

    public string? NameCustomer { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string ObjectName { get; set; } = null!;

    public string Capacity { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime DateBill { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual OutputInfo IdOutputInfoNavigation { get; set; } = null!;
}
