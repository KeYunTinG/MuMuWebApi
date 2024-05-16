using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class SubComment
{
    public int SubCommentId { get; set; }

    public int? CommentId { get; set; }

    public int? MemberId { get; set; }

    public string? SubCommentMsg { get; set; }

    public DateTime? Date { get; set; }

    public virtual Comment? Comment { get; set; }

    public virtual Member? Member { get; set; }
}
