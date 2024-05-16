using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public int? MemberId { get; set; }

    public string? ServiceMsg { get; set; }

    public byte? Status { get; set; }

    public DateTime? Date { get; set; }

    public virtual Member? Member { get; set; }
}
