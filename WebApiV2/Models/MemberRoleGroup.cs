using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class MemberRoleGroup
{
    public int MemberRoleGroupId { get; set; }

    public int MemberId { get; set; }

    public int RoleId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
