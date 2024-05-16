using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class Like
{
    public int LikeId { get; set; }

    public int? MemberId { get; set; }

    public int? ProjectId { get; set; }

    public virtual ICollection<LikeDetail> LikeDetails { get; set; } = new List<LikeDetail>();

    public virtual Member? Member { get; set; }

    public virtual Project? Project { get; set; }
}
