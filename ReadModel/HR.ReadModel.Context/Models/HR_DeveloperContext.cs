using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class HR_DeveloperContext : DbContext
    {
        public HR_DeveloperContext()
        {
        }

        public HR_DeveloperContext(DbContextOptions<HR_DeveloperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeContract> EmployeeContracts { get; set; }
        public virtual DbSet<EmployeeIo> EmployeeIos { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<ShiftAssignment> ShiftAssignments { get; set; }
        public virtual DbSet<ShiftSegment> ShiftSegments { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.2.252;Database=HR_Developer;Trusted_Connection=True;User Id = saleadmin; Password = 123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "EmployeeContext");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SettlementDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeContract>(entity =>
            {
                entity.ToTable("EmployeeContract", "EmployeeContext");

                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeContract_EmployeeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeContracts)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<EmployeeIo>(entity =>
            {
                entity.ToTable("EmployeeIo", "EmployeeContext");

                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeIo_EmployeeId");

                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeIo_EmployeeId2");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeIos)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift", "ShiftContext");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ShiftAssignment>(entity =>
            {
                entity.ToTable("ShiftAssignment", "EmployeeContext");

                entity.HasIndex(e => e.EmployeeId, "IX_ShiftAssignment_EmployeeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ShiftAssignments)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<ShiftSegment>(entity =>
            {
                entity.ToTable("ShiftSegment", "ShiftContext");

                entity.HasIndex(e => e.ShiftId, "IX_ShiftSegment_ShiftId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.ShiftSegments)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_Shift_ShiftSegment");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit", "DefinitionContext");

                entity.HasIndex(e => e.Title, "IX_Unit_Title")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
