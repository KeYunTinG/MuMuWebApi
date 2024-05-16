using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class ProjectType
{
    public int ProjectTypeId { get; set; }

    public string ProjectTypeName { get; set; } = null!;

    public virtual ICollection<MemberInterestProjectType> MemberInterestProjectTypes { get; set; } = new List<MemberInterestProjectType>();

    public virtual ICollection<ProjectIdtype> ProjectIdtypes { get; set; } = new List<ProjectIdtype>();
}
