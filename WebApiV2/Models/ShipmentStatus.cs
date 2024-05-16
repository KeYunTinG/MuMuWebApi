using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class ShipmentStatus
{
    public int ShipmentStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
