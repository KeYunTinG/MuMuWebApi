using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class MemberInterestProjectType
{
    public int MemberInterestProjectTypeId { get; set; }

    public int ProjectTypeId { get; set; }

    public int MemberId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ProjectType ProjectType { get; set; } = null!;
}
