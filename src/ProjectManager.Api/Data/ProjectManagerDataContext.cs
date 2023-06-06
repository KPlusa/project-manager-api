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
            entity.HasKey(e => e.IdProject)
                .HasName("PK_PROJEKT")
                .IsClustered(false);

            entity.ToTable("project");

            entity.HasIndex(e => e.IdType, "projekt_rodzaj_FK");

            entity.HasIndex(e => e.IdStatus, "projekt_status_FK");

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
                .HasConstraintName("FK_PROJEKT_PROJEKT_S_STATUS");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROJEKT_PROJEKT_R_RODZAJ");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus)
                .HasName("PK_STATUS")
                .IsClustered(false);

            entity.ToTable("status");

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.IdType)
                .HasName("PK_RODZAJ")
                .IsClustered(false);

            entity.ToTable("type");

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
