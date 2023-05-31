using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.Model;

public partial class ForeignTripsContext : DbContext
{
    public ForeignTripsContext()
    {
    }

    public ForeignTripsContext(DbContextOptions<ForeignTripsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminTbl> AdminTbls { get; set; }

    public virtual DbSet<AgentTbl> AgentTbls { get; set; }

    public virtual DbSet<CityTbl> CityTbls { get; set; }

    public virtual DbSet<LoginTbl> LoginTbls { get; set; }

    public virtual DbSet<ProvinceTbl> ProvinceTbls { get; set; }

    public virtual DbSet<RequestStatusTbl> RequestStatusTbls { get; set; }

    public virtual DbSet<RequestTbl> RequestTbls { get; set; }

    public virtual DbSet<RequestTravelTbl> RequestTravelTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Foreign Trips;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminTbl>(entity =>
        {
            entity.HasKey(e => e.AdminId);

            entity.ToTable("AdminTbl");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AdminUsername).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(300);
        });

        modelBuilder.Entity<AgentTbl>(entity =>
        {
            entity.HasKey(e => e.AgentId);

            entity.ToTable("AgentTbl");

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.AgentName).HasMaxLength(100);
            entity.Property(e => e.BirthCertificateId).HasColumnName("BirthCertificateID");
            entity.Property(e => e.CittyCertificateId)
                .HasMaxLength(50)
                .HasColumnName("CittyCertificateID");
            entity.Property(e => e.CityBirthCertificateIssuingPlace).HasMaxLength(50);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Mobile).HasMaxLength(11);
            entity.Property(e => e.NationalCode).HasMaxLength(10);
            entity.Property(e => e.Password).HasMaxLength(300);
            entity.Property(e => e.ProviceBirthCertificateIssuingPlace).HasMaxLength(50);
            entity.Property(e => e.ProvinceCertificateId)
                .HasMaxLength(50)
                .HasColumnName("ProvinceCertificateID");
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(5);

            entity.HasOne(d => d.City).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_CityTbl");
        });

        modelBuilder.Entity<CityTbl>(entity =>
        {
            entity.HasKey(e => e.CityId);

            entity.ToTable("CityTbl");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName).HasMaxLength(250);
            entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");
            entity.Property(e => e.ProvinceName).HasMaxLength(250);

            entity.HasOne(d => d.Province).WithMany(p => p.CityTbls)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CityTbl_ProvinceTbl1");
        });

        modelBuilder.Entity<LoginTbl>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.ToTable("LoginTbl");

            entity.Property(e => e.LoginId).HasColumnName("LoginID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Date).HasMaxLength(10);
            entity.Property(e => e.Time).HasMaxLength(10);

            entity.HasOne(d => d.Agent).WithMany(p => p.LoginTbls)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LoginTbl_AgentTbl1");
        });

        modelBuilder.Entity<ProvinceTbl>(entity =>
        {
            entity.HasKey(e => e.ProvinceId);

            entity.ToTable("ProvinceTbl");

            entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");
            entity.Property(e => e.ProvinceName).HasMaxLength(250);
        });

        modelBuilder.Entity<RequestStatusTbl>(entity =>
        {
            entity.HasKey(e => e.RequestStatusId);

            entity.ToTable("RequestStatusTbl");

            entity.Property(e => e.RequestStatusId).HasColumnName("RequestStatusID");
        });

        modelBuilder.Entity<RequestTbl>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("RequestTbl");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.ConfirmDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DestinationCountry).HasMaxLength(50);
            entity.Property(e => e.NationalCode).HasMaxLength(10);
            entity.Property(e => e.Payer).HasMaxLength(100);
            entity.Property(e => e.RejectDescription).HasMaxLength(300);
            entity.Property(e => e.RequestName).HasMaxLength(100);
            entity.Property(e => e.RequestStatusId).HasColumnName("RequestStatusID");
            entity.Property(e => e.Role).HasMaxLength(100);
            entity.Property(e => e.TravelDate).HasMaxLength(50);
            entity.Property(e => e.TravelTime).HasMaxLength(5);
            entity.Property(e => e.TravelTopic).HasMaxLength(300);
            entity.Property(e => e.TypeOfEmployment).HasMaxLength(50);
            entity.Property(e => e.WorkLocation).HasMaxLength(200);

            entity.HasOne(d => d.Agent).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_RequestTbl3");

            entity.HasOne(d => d.RequestStatus).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.RequestStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_RequestTbl");
        });

        modelBuilder.Entity<RequestTravelTbl>(entity =>
        {
            entity.HasKey(e => e.RequestTravelId);

            entity.ToTable("RequestTravelTbl");

            entity.Property(e => e.RequestTravelId).HasColumnName("RequestTravelID");
            entity.Property(e => e.DestinationCountry).HasMaxLength(50);
            entity.Property(e => e.NameAgent).HasMaxLength(100);
            entity.Property(e => e.NationalCode).HasMaxLength(50);
            entity.Property(e => e.PersonUpName).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(100);
            entity.Property(e => e.TravelDate).HasMaxLength(10);
            entity.Property(e => e.TravelExpensePayer).HasMaxLength(100);
            entity.Property(e => e.TravelTime).HasMaxLength(5);
            entity.Property(e => e.TravelTopic).HasMaxLength(300);
            entity.Property(e => e.TypeOfEmployment).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
