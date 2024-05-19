using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public decimal Goal { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly ExpireDate { get; set; }

    public int MemberId { get; set; }

    public int RoleId { get; set; }

    public string? Description { get; set; }

    public string? Thumbnail { get; set; }

    public double? Discount { get; set; }

    public decimal? AccumulatedAmount { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    //public virtual Member Member { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<ProjectEditPermission> ProjectEditPermissions { get; set; } = new List<ProjectEditPermission>();

    public virtual ICollection<ProjectIdtype> ProjectIdtypes { get; set; } = new List<ProjectIdtype>();

    // public virtual Role Role { get; set; } = null!;
}
