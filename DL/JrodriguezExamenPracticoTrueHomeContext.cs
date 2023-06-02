using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class JrodriguezExamenPracticoTrueHomeContext : DbContext
{
    public JrodriguezExamenPracticoTrueHomeContext()
    {
    }

    public JrodriguezExamenPracticoTrueHomeContext(DbContextOptions<JrodriguezExamenPracticoTrueHomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= JRodriguezExamenPracticoTrueHome; User ID=sa; TrustServerCertificate=True; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.IdActivity).HasName("PK__Activity__EB66AD2B78B7B39E");

            entity.ToTable("Activity");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.ScheduleFinal)
                .HasColumnType("datetime")
                .HasColumnName("Schedule_Final");
            entity.Property(e => e.ScheduleInicial)
                .HasColumnType("datetime")
                .HasColumnName("Schedule_Inicial");
            entity.Property(e => e.Status)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Tittle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.IdPropertyNavigation).WithMany(p => p.Activities)
                .HasForeignKey(d => d.IdProperty)
                .HasConstraintName("FK__Activity__IdProp__1B0907CE");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.IdProperty).HasName("PK__Property__6C08B9A7966C48C5");

            entity.ToTable("Property");

            entity.Property(e => e.IdProperty).HasColumnName("idProperty");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.DisabledAt)
                .HasColumnType("datetime")
                .HasColumnName("Disabled_at");
            entity.Property(e => e.Status)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Tittle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.IdSurvey).HasName("PK__Survey__A2290710149DA4D3");

            entity.ToTable("Survey");

            entity.Property(e => e.ActivityId).HasColumnName("Activity_Id");
            entity.Property(e => e.Answer).IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_at");

            entity.HasOne(d => d.Activity).WithMany(p => p.Surveys)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK__Survey__Activity__15502E78");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
