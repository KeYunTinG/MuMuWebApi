using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class ProjectEditPermission
{
    public int ProjectEditPermissionId { get; set; }

    public int ProjectId { get; set; }

    public int MemberId { get; set; }

    public int PermissionLevelId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual PermissionLevel PermissionLevel { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
