using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Api.Data;

public partial class ProjectManagerDataContext : DbContext
{
    public ProjectManagerDataContext(DbContextOptions<ProjectManagerDataContext> options, IConfiguration configuration)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; } = null!;

    public virtual DbSet<Status> Statuses { get; set; } = null!;

    public virtual DbSet<Type> Types { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject).HasName("PK__project__274AE1B335BE8068");

            entity.ToTable("project");

            entity.HasIndex(e => e.ProjectTitle, "UQ__project__125CEB0A13A06F9B").IsUnique();

            entity.HasIndex(e => e.ProjectNo, "UQ__project__BC79D7FA001E6F67").IsUnique();

            entity.Property(e => e.IdProject).HasColumnName("id_project");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.ProjectNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("project_no");
            entity.Property(e => e.ProjectTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("project_title");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__project__id_stat__3F466844");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__project__id_type__3E52440B");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__status__5D2DC6E8ACE9A308");

            entity.ToTable("status");

            entity.HasIndex(e => e.StatusName, "UQ__status__A9BE6F7622972B31").IsUnique();

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PK__type__C3F091E069A8388C");

            entity.ToTable("type");

            entity.HasIndex(e => e.TypeName, "UQ__type__543C4FD9E9A94EC2").IsUnique();

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}