using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiV2.Models;

public partial class ZecZecContext : DbContext
{
    public ZecZecContext()
    {
    }

    public ZecZecContext(DbContextOptions<ZecZecContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<LikeDetail> LikeDetails { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberInterestProjectType> MemberInterestProjectTypes { get; set; }

    public virtual DbSet<MemberRoleGroup> MemberRoleGroups { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }

    public virtual DbSet<PermissionLevel> PermissionLevels { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectEditPermission> ProjectEditPermissions { get; set; }

    public virtual DbSet<ProjectIdtype> ProjectIdtypes { get; set; }

    public virtual DbSet<ProjectType> ProjectTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ShipmentStatus> ShipmentStatuses { get; set; }

    public virtual DbSet<SubComment> SubComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ZecZec;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartsId);

            entity.Property(e => e.CartsId).HasColumnName("CartsID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Member).WithMany(p => p.Carts)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Carts_Members");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Carts_Products");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Member).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Comments_Members");

            entity.HasOne(d => d.Project).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Comments_Projects");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.Property(e => e.LikeId).HasColumnName("LikeID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Member).WithMany(p => p.Likes)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Likes_Members");

            entity.HasOne(d => d.Project).WithMany(p => p.Likes)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Likes_Projects");
        });

        modelBuilder.Entity<LikeDetail>(entity =>
        {
            entity.HasKey(e => e.LikeDetailsId);

            entity.Property(e => e.LikeDetailsId).HasColumnName("LikeDetailsID");
            entity.Property(e => e.LikeId).HasColumnName("LikeID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Like).WithMany(p => p.LikeDetails)
                .HasForeignKey(d => d.LikeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LikeDetails_Likes");

            entity.HasOne(d => d.Member).WithMany(p => p.LikeDetails)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LikeDetails_Members");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nickname).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Thumbnail).HasMaxLength(50);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MemberInterestProjectType>(entity =>
        {
            entity.ToTable("MemberInterestProjectType");

            entity.Property(e => e.MemberInterestProjectTypeId).HasColumnName("MemberInterestProjectTypeID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ProjectTypeId).HasColumnName("ProjectTypeID");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberInterestProjectTypes)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberInterestProjectType_Members");

            entity.HasOne(d => d.ProjectType).WithMany(p => p.MemberInterestProjectTypes)
                .HasForeignKey(d => d.ProjectTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberInterestProjectType_ProjectTypes");
        });

        modelBuilder.Entity<MemberRoleGroup>(entity =>
        {
            entity.ToTable("MemberRoleGroup");

            entity.Property(e => e.MemberRoleGroupId).HasColumnName("MemberRoleGroupID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberRoleGroups)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberRoleGroup_Members");

            entity.HasOne(d => d.Role).WithMany(p => p.MemberRoleGroups)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberRoleGroup_Roles");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Donate).HasColumnType("money");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.ShipmentStatusId).HasColumnName("ShipmentStatusID");

            entity.HasOne(d => d.Member).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Members1");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_PaymentMethods");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_PaymentStatus");

            entity.HasOne(d => d.ShipmentStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipmentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_ShipmentStatus");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.PaymentMethodName).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentStatus>(entity =>
        {
            entity.ToTable("PaymentStatus");

            entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");
            entity.Property(e => e.PaymentStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<PermissionLevel>(entity =>
        {
            entity.Property(e => e.PermissionLevelId).HasColumnName("PermissionLevelID");
            entity.Property(e => e.PermissionLevelName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Thumbnail).HasMaxLength(50);

            entity.HasOne(d => d.Project).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Projects");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.AccumulatedAmount).HasColumnType("money");
            entity.Property(e => e.Goal).HasColumnType("money");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ProjectName).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Thumbnail).HasMaxLength(50);

            /*entity.HasOne(d => d.Member).WithMany(p => p.Projects)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projects_Members");

            entity.HasOne(d => d.Role).WithMany(p => p.Projects)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Projects_Roles");*/
        });

        modelBuilder.Entity<ProjectEditPermission>(entity =>
        {
            entity.Property(e => e.ProjectEditPermissionId).HasColumnName("ProjectEditPermissionID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.PermissionLevelId).HasColumnName("PermissionLevelID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Member).WithMany(p => p.ProjectEditPermissions)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectEditPermissions_Members");

            entity.HasOne(d => d.PermissionLevel).WithMany(p => p.ProjectEditPermissions)
                .HasForeignKey(d => d.PermissionLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectEditPermissions_PermissionLevels");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectEditPermissions)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectEditPermissions_Projects");
        });

        modelBuilder.Entity<ProjectIdtype>(entity =>
        {
            entity.ToTable("ProjectIDType");

            entity.Property(e => e.ProjectIdtypeId).HasColumnName("ProjectIDTypeID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectTypeId).HasColumnName("ProjectTypeID");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectIdtypes)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectIDType_Projects");

            entity.HasOne(d => d.ProjectType).WithMany(p => p.ProjectIdtypes)
                .HasForeignKey(d => d.ProjectTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectIDType_ProjectTypes");
        });

        modelBuilder.Entity<ProjectType>(entity =>
        {
            entity.Property(e => e.ProjectTypeId).HasColumnName("ProjectTypeID");
            entity.Property(e => e.ProjectTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(30);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Member).WithMany(p => p.Services)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Service_Members");
        });

        modelBuilder.Entity<ShipmentStatus>(entity =>
        {
            entity.ToTable("ShipmentStatus");

            entity.Property(e => e.ShipmentStatusId).HasColumnName("ShipmentStatusID");
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<SubComment>(entity =>
        {
            entity.Property(e => e.SubCommentId).HasColumnName("SubCommentID");
            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Comment).WithMany(p => p.SubComments)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK_SubComments_Comments");

            entity.HasOne(d => d.Member).WithMany(p => p.SubComments)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_SubComments_Members");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
