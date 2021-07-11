﻿// <auto-generated />
using System;
using HR.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HR.Persistence.Migrations
{
    [DbContext(typeof(HRDbContext))]
    [Migration("20210627061618_RemoveShiftTemplate")]
    partial class RemoveShiftTemplate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HR.EmployeeContext.Domain.EmployeeIos.EmployeeIo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("UniqueIdentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeIo", "EmployeeContext");
                });

            modelBuilder.Entity("HR.EmployeeContext.Domain.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Employee", "EmployeeContext");
                });

            modelBuilder.Entity("HR.EmployeeContext.Domain.Employees.ShiftAssignment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ShiftId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ShiftAssignment", "EmployeeContext");
                });

            modelBuilder.Entity("HR.ShiftContext.Domain.Shifts.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Shift", "ShiftContext");
                });

            modelBuilder.Entity("HR.ShiftContext.Domain.Shifts.ShiftSegment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<Guid?>("NextShiftId")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<Guid>("ShiftId")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ShiftId");

                    b.ToTable("ShiftSegment", "ShiftContext");
                });

            modelBuilder.Entity("HR.EmployeeContext.Domain.EmployeeIos.EmployeeIo", b =>
                {
                    b.HasOne("HR.EmployeeContext.Domain.Employees.Employee", null)
                        .WithMany("EmployeeIos")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HR.EmployeeContext.Domain.Employees.ShiftAssignment", b =>
                {
                    b.HasOne("HR.EmployeeContext.Domain.Employees.Employee", null)
                        .WithMany("ShiftAssignments")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("HR.ShiftContext.Domain.Shifts.ShiftSegment", b =>
                {
                    b.HasOne("HR.ShiftContext.Domain.Shifts.Shift", null)
                        .WithMany("ShiftSegments")
                        .HasForeignKey("ShiftId")
                        .HasConstraintName("FK_Shift_ShiftSegment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HR.EmployeeContext.Domain.Employees.Employee", b =>
                {
                    b.Navigation("EmployeeIos");

                    b.Navigation("ShiftAssignments");
                });

            modelBuilder.Entity("HR.ShiftContext.Domain.Shifts.Shift", b =>
                {
                    b.Navigation("ShiftSegments");
                });
#pragma warning restore 612, 618
        }
    }
}
