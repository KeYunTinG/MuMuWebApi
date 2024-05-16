using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class PaymentStatus
{
    public int PaymentStatusId { get; set; }

    public string PaymentStatusName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
