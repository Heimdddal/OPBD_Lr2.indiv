using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OPBD_Lr2.indiv;

public partial class OpbdLr22Context : DbContext
{
    public OpbdLr22Context()
    {
    }

    public OpbdLr22Context(DbContextOptions<OpbdLr22Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\dimas\\OneDrive\\Рабочий стол\\OPBD_Lr2.2.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employeeId");
            entity.Property(e => e.BirthDate).HasColumnType("text(11)");
            entity.Property(e => e.Gender).HasColumnType("text(1)");
            entity.Property(e => e.PassportNumber).HasColumnType("text(6)");
            entity.Property(e => e.PassportSeries).HasColumnType("text(4)");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees).HasForeignKey(d => d.PositionId);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.Property(e => e.ManufacturerId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.Manufacturers).HasForeignKey(d => d.EmployeeId);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.PositionId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
