using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<DanceStyle> DanceStyles { get; set; }
        public virtual DbSet<Dancer> Dancers { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupHasDancer> GroupHasDancers { get; set; }
        public virtual DbSet<Hour> Hours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=mydb;Uid=root;password=DpVeR6UX;", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.HasIndex(e => e.GroupId)
                    .HasName("fk_Class_Group1_idx");

                entity.HasIndex(e => e.HourId)
                    .HasName("hour_id_idx");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");

                entity.Property(e => e.DancestyleId)
                    .IsRequired()
                    .HasColumnName("dancestyle_id")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.HourId).HasColumnName("hour_id");

                entity.Property(e => e.Weekday)
                    .HasColumnName("weekday")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Class_Group1");

                entity.HasOne(d => d.Hour)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.HourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk hour");
            });

            modelBuilder.Entity<DanceStyle>(entity =>
            {
                entity.ToTable("dance_style");

                entity.HasIndex(e => e.DancestyleId)
                    .HasName("dancestyle_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DancestyleId).HasColumnName("dancestyle_id");

                entity.Property(e => e.DancestyleName)
                    .IsRequired()
                    .HasColumnName("dancestyle_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Dancer>(entity =>
            {
                entity.ToTable("dancer");

                entity.HasIndex(e => e.FunctionId)
                    .HasName("fk_Dancer_Function1_idx");

                entity.Property(e => e.DancerId).HasColumnName("dancer_id");

                entity.Property(e => e.FunctionId).HasColumnName("function_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("varchar(35)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Dancers)
                    .HasForeignKey(d => d.FunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Dancer_Function1");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("function");

                entity.Property(e => e.FunctionId).HasColumnName("function_id");

                entity.Property(e => e.FunctionName)
                    .HasColumnName("function_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity.HasIndex(e => e.DancestyleId)
                    .HasName("fk_Group_Dance_style1_idx");

                entity.HasIndex(e => e.GroupName)
                    .HasName("group_name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.SupervisorId)
                    .HasName("fk_supervisor_idx");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.DancestyleId).HasColumnName("dancestyle_id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SupervisorId).HasColumnName("Supervisor_id");

                entity.HasOne(d => d.Dancestyle)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.DancestyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Group_Dance_style1");
            });

            modelBuilder.Entity<GroupHasDancer>(entity =>
            {
                entity.HasKey(e => new { e.GroupGroupId, e.DancerDancerId })
                    .HasName("PRIMARY");

                entity.ToTable("group_has_dancer");

                entity.HasIndex(e => e.DancerDancerId)
                    .HasName("Dancer_id_idx");

                entity.HasIndex(e => e.GroupGroupId)
                    .HasName("fk_Group_has_Dancer_Group1_idx");

                entity.Property(e => e.GroupGroupId).HasColumnName("Group_group_id");

                entity.Property(e => e.DancerDancerId).HasColumnName("Dancer_dancer_id");

                entity.HasOne(d => d.DancerDancer)
                    .WithMany(p => p.GroupHasDancers)
                    .HasForeignKey(d => d.DancerDancerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dancer_id");

                entity.HasOne(d => d.GroupGroup)
                    .WithMany(p => p.GroupHasDancers)
                    .HasForeignKey(d => d.GroupGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Group_id");
            });

            modelBuilder.Entity<Hour>(entity =>
            {
                entity.ToTable("hours");

                entity.Property(e => e.HourId).HasColumnName("hour_id");

                entity.Property(e => e.HourEnd).HasColumnName("hour_end");

                entity.Property(e => e.HourStart).HasColumnName("hour_start");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
