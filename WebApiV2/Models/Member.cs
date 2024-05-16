using System;
using System.Collections.Generic;

namespace WebApiV2.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Nickname { get; set; }

    public string? Thumbnail { get; set; }

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? MemberIntroduction { get; set; }

    public DateOnly? CreateTime { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<LikeDetail> LikeDetails { get; set; } = new List<LikeDetail>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<MemberInterestProjectType> MemberInterestProjectTypes { get; set; } = new List<MemberInterestProjectType>();

    public virtual ICollection<MemberRoleGroup> MemberRoleGroups { get; set; } = new List<MemberRoleGroup>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProjectEditPermission> ProjectEditPermissions { get; set; } = new List<ProjectEditPermission>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<SubComment> SubComments { get; set; } = new List<SubComment>();
}
