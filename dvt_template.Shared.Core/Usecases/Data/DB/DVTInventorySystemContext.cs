using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dvt_template.Shared.Core.DB
{
    public partial class DVTInventorySystemContext : DbContext
    {
        public DVTInventorySystemContext()
        {
        }

        public DVTInventorySystemContext(DbContextOptions<DVTInventorySystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<AssetAllocation> AssetAllocation { get; set; }
        public virtual DbSet<AssetStatus> AssetStatus { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=grads2018.database.windows.net;Database=DVTInventorySystem;User Id=Training; Password=SqlAdmin@1;");
            }
        }
#warning Hello!!!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.HasKey(e => e.SerialNumber);

                entity.Property(e => e.AssetModel).HasMaxLength(20);

                entity.Property(e => e.AssetTypeId).HasColumnName("AssetTypeID");

                entity.HasOne(d => d.AssetType)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.AssetTypeId)
                    .HasConstraintName("FK_Asset_AssetType");
            });

            modelBuilder.Entity<AssetAllocation>(entity =>
            {
                entity.HasKey(e => e.AllocationId);

                entity.Property(e => e.AllocationId).HasColumnName("AllocationID");

                entity.Property(e => e.AssetStatusId).HasColumnName("AssetStatusID");

                entity.Property(e => e.DateAllocated).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AssetStatus)
                    .WithMany(p => p.AssetAllocation)
                    .HasForeignKey(d => d.AssetStatusId)
                    .HasConstraintName("FK_AssetAllocation_AssetStatus");

                entity.HasOne(d => d.SerialNumberNavigation)
                    .WithMany(p => p.AssetAllocation)
                    .HasForeignKey(d => d.SerialNumber)
                    .HasConstraintName("FK_AssetAllocation_Asset");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AssetAllocation)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AssetAllocation_User");
            });

            modelBuilder.Entity<AssetStatus>(entity =>
            {
                entity.Property(e => e.AssetStatusId).HasColumnName("AssetStatusID");

                entity.Property(e => e.Desscription).HasMaxLength(20);
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.Property(e => e.AssetTypeId).HasColumnName("AssetTypeID");

                entity.Property(e => e.Description).HasMaxLength(20);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentLocation).HasMaxLength(30);

                entity.Property(e => e.DepartmentName).HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_User_Department");
            });
        }
    }
}
