using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class LikeDetail
{
    public int LikeDetailsId { get; set; }

    public int LikeId { get; set; }

    public int MemberId { get; set; }

    public virtual Like Like { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
