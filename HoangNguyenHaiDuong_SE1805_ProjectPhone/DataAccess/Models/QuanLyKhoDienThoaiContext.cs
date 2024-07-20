using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class QuanLyKhoDienThoaiContext : DbContext
{
    public QuanLyKhoDienThoaiContext()
    {
    }

    public QuanLyKhoDienThoaiContext(DbContextOptions<QuanLyKhoDienThoaiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillHistory> BillHistories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Input> Inputs { get; set; }

    public virtual DbSet<InputInfo> InputInfos { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<ObjectDetail> ObjectDetails { get; set; }

    public virtual DbSet<Output> Outputs { get; set; }

    public virtual DbSet<OutputInfo> OutputInfos { get; set; }

    public virtual DbSet<Suplier> Supliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-L3BH5CT9\\DUONG;Initial Catalog=QuanLyKhoDienThoai; Trusted_Connection=SSPI;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BillHist__3214EC0737627B79");

            entity.ToTable("BillHistory");

            entity.Property(e => e.Capacity).HasMaxLength(100);
            entity.Property(e => e.DateBill).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.NameCustomer).HasMaxLength(100);
            entity.Property(e => e.ObjectName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.BillHistories)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillHisto__IdCus__4222D4EF");

            entity.HasOne(d => d.IdOutputInfoNavigation).WithMany(p => p.BillHistories)
                .HasForeignKey(d => d.IdOutputInfo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillHisto__IdOut__4316F928");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07015A0DF8");

            entity.ToTable("Customer");

            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Input>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Input__3214EC075FFB188A");

            entity.ToTable("Input");

            entity.Property(e => e.DateInput).HasColumnType("datetime");
        });

        modelBuilder.Entity<InputInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InputInf__3214EC073FC44BAF");

            entity.ToTable("InputInfo");

            entity.Property(e => e.Capacity).HasMaxLength(100);
            entity.Property(e => e.InputPrice).HasDefaultValue(0.0);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.IdInputNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdInput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__IdInp__398D8EEE");

            entity.HasOne(d => d.IdObjectNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdObject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__IdObj__3A81B327");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.InputInfos)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InputInfo__IdUse__3B75D760");
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Object__3214EC07603819AD");

            entity.ToTable("Object");

            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.IdSuplierNavigation).WithMany(p => p.Objects)
                .HasForeignKey(d => d.IdSuplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Object__IdSuplie__3C69FB99");
        });

        modelBuilder.Entity<ObjectDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ObjectDe__3214EC078812E78F");

            entity.ToTable("ObjectDetail");

            entity.HasOne(d => d.IdObjectNavigation).WithMany(p => p.ObjectDetails)
                .HasForeignKey(d => d.IdObject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ObjectDet__IdObj__2C3393D0");
        });

        modelBuilder.Entity<Output>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Output__3214EC07482F13E4");

            entity.ToTable("Output");

            entity.Property(e => e.DateOutput).HasColumnType("datetime");
        });

        modelBuilder.Entity<OutputInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OutputIn__3214EC07388E3BDE");

            entity.ToTable("OutputInfo");

            entity.Property(e => e.Capacity).HasMaxLength(100);

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdCus__3E52440B");

            entity.HasOne(d => d.IdObjectNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdObject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdObj__3F466844");

            entity.HasOne(d => d.IdOutputNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdOutput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutputInf__IdOut__3D5E1FD2");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.OutputInfos)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__OutputInf__IdUse__403A8C7D");
        });

        modelBuilder.Entity<Suplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Suplier__3214EC0740DCB932");

            entity.ToTable("Suplier");

            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0784C9895B");

            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__IdRole__412EB0B6");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC0764EF8230");

            entity.ToTable("UserRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
