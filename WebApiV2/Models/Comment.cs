using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? MemberId { get; set; }

    public int? ProjectId { get; set; }

    public string? CommentMsg { get; set; }

    public DateTime? Date { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<SubComment> SubComments { get; set; } = new List<SubComment>();
}
