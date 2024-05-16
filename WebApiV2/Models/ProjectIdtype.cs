using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class ProjectIdtype
{
    public int ProjectIdtypeId { get; set; }

    public int ProjectId { get; set; }

    public int ProjectTypeId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectType ProjectType { get; set; } = null!;
}
