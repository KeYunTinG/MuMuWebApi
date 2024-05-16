using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class Cart
{
    public int CartsId { get; set; }

    public int? MemberId { get; set; }

    public int? ProductId { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Product? Product { get; set; }
}
