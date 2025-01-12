using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace teachmeet_api.Entities;

public partial class TeachmeetdbContext : DbContext
{
    public TeachmeetdbContext(DbContextOptions<TeachmeetdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<FacultyOfficeTime> FacultyOfficeTimes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<OfficeTiming> OfficeTimings { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC27E58F5FE6");

            entity.ToTable("Department");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LiveData)
                .HasDefaultValue(true)
                .HasColumnName("Live_Data");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Facultie__3214EC2786EC157F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.GenderId).HasColumnName("Gender_ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LiveData)
                .HasDefaultValue(true)
                .HasColumnName("Live_Data");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Mobile_Number");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProfileImage)
                .IsUnicode(false)
                .HasColumnName("Profile_Image");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TitleId).HasColumnName("Title_ID");

            entity.HasOne(d => d.Department).WithMany(p => p.Faculties)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Faculties__Depar__46E78A0C");

            entity.HasOne(d => d.Gender).WithMany(p => p.Faculties)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Faculties__Gende__47DBAE45");

            entity.HasOne(d => d.Title).WithMany(p => p.Faculties)
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("FK__Faculties__Title__45F365D3");
        });

        modelBuilder.Entity<FacultyOfficeTime>(entity =>
        {
            entity.ToTable("FacultyOfficeTime");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FacId).HasColumnName("FacID");
            entity.Property(e => e.OfficeTimeId).HasColumnName("OfficeTimeID");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gender__3214EC27AEEAA676");

            entity.ToTable("Gender");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LiveData)
                .HasDefaultValue(true)
                .HasColumnName("Live_Data");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OfficeTiming>(entity =>
        {
            entity.ToTable("OfficeTiming");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Day)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndTime).HasPrecision(0);
            entity.Property(e => e.StartTime).HasPrecision(0);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.GenderId).HasColumnName("Gender_ID");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LiveData).HasColumnName("Live_Data");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Mobile_Number");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProfileImage)
                .IsUnicode(false)
                .HasColumnName("Profile_Image");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Title__3214EC27557EBC9B");

            entity.ToTable("Title");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LiveData)
                .HasDefaultValue(true)
                .HasColumnName("Live_Data");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserType__3214EC27F2EE8CA5");

            entity.ToTable("UserType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LiveData)
                .HasDefaultValue(true)
                .HasColumnName("Live_Data");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
