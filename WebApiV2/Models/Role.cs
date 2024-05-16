using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<MemberRoleGroup> MemberRoleGroups { get; set; } = new List<MemberRoleGroup>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
