using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int ProjectId { get; set; }

    public decimal Price { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public int Quantity { get; set; }

    public int Inventory { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly ExpireDate { get; set; }

    public string? Thumbnail { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Project Project { get; set; } = null!;
}
