using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class PermissionLevel
{
    public int PermissionLevelId { get; set; }

    public string PermissionLevelName { get; set; } = null!;

    public string PermissionLevelDescription { get; set; } = null!;

    public virtual ICollection<ProjectEditPermission> ProjectEditPermissions { get; set; } = new List<ProjectEditPermission>();
}
