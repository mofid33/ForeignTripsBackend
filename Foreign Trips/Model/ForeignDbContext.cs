﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.Model;

public partial class ForeignDbContext : DbContext
{
    public ForeignDbContext()
    {
    }

    public ForeignDbContext(DbContextOptions<ForeignDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgentStatusTbl> AgentStatusTbls { get; set; }

    public virtual DbSet<AgentTbl> AgentTbls { get; set; }

    public virtual DbSet<CityTbl> CityTbls { get; set; }

    public virtual DbSet<CountryTbl> CountryTbls { get; set; }

    public virtual DbSet<DispatcherSelectionTbl> DispatcherSelectionTbls { get; set; }

    public virtual DbSet<ExpertSelectionTbl> ExpertSelectionTbls { get; set; }

    public virtual DbSet<FileDetailsTbl> FileDetailsTbls { get; set; }

    public virtual DbSet<FileTypeTbl> FileTypeTbls { get; set; }

    public virtual DbSet<ForeignDelegrationTbl> ForeignDelegrationTbls { get; set; }

    public virtual DbSet<GenderTypeTbl> GenderTypeTbls { get; set; }

    public virtual DbSet<InfoTbl> InfoTbls { get; set; }

    public virtual DbSet<InternationalAdminTbl> InternationalAdminTbls { get; set; }

    public virtual DbSet<InternationalExpertTbl> InternationalExpertTbls { get; set; }

    public virtual DbSet<JobGoalsTypeTbl> JobGoalsTypeTbls { get; set; }

    public virtual DbSet<LanguageTypeTbl> LanguageTypeTbls { get; set; }

    public virtual DbSet<LoginTbl> LoginTbls { get; set; }

    public virtual DbSet<MainAdminTbl> MainAdminTbls { get; set; }

    public virtual DbSet<MaritalStatusTbl> MaritalStatusTbls { get; set; }

    public virtual DbSet<MessageTbl> MessageTbls { get; set; }

    public virtual DbSet<OperationTypeTbl> OperationTypeTbls { get; set; }

    public virtual DbSet<ParticipantTbl> ParticipantTbls { get; set; }

    public virtual DbSet<PassportTbl> PassportTbls { get; set; }

    public virtual DbSet<PassportTypeTbl> PassportTypeTbls { get; set; }

    public virtual DbSet<PositionTypeTbl> PositionTypeTbls { get; set; }

    public virtual DbSet<ReciverMessageTbl> ReciverMessageTbls { get; set; }

    public virtual DbSet<ReportStatusTbl> ReportStatusTbls { get; set; }

    public virtual DbSet<ReportTbl> ReportTbls { get; set; }

    public virtual DbSet<RequestEmployeeTbl> RequestEmployeeTbls { get; set; }

    public virtual DbSet<RequestStatusTbl> RequestStatusTbls { get; set; }

    public virtual DbSet<RequestTbl> RequestTbls { get; set; }

    public virtual DbSet<RightOfCommutingTypeTbl> RightOfCommutingTypeTbls { get; set; }

    public virtual DbSet<RightOfMissionTbl> RightOfMissionTbls { get; set; }

    public virtual DbSet<RightToEducationTbl> RightToEducationTbls { get; set; }

    public virtual DbSet<SignatureRequestTbl> SignatureRequestTbls { get; set; }

    public virtual DbSet<SubCategoryTbl> SubCategoryTbls { get; set; }

    public virtual DbSet<SubsidiaryOrganizationTypeTbl> SubsidiaryOrganizationTypeTbls { get; set; }

    public virtual DbSet<SupervisorTbl> SupervisorTbls { get; set; }

    public virtual DbSet<TicketDetailsTbl> TicketDetailsTbls { get; set; }

    public virtual DbSet<TicketStatusTbl> TicketStatusTbls { get; set; }

    public virtual DbSet<TicketTbl> TicketTbls { get; set; }

    public virtual DbSet<TicketTypeTbl> TicketTypeTbls { get; set; }

    public virtual DbSet<TollAmountTypeTbl> TollAmountTypeTbls { get; set; }

    public virtual DbSet<TravelGoalsTypeTbl> TravelGoalsTypeTbls { get; set; }

    public virtual DbSet<TravelTypeTbl> TravelTypeTbls { get; set; }

    public virtual DbSet<TypeAccommodationTbl> TypeAccommodationTbls { get; set; }

    public virtual DbSet<TypeOfEmploymentTbl> TypeOfEmploymentTbls { get; set; }

    public virtual DbSet<TypeOfMissionTbl> TypeOfMissionTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=rogstrix.com;Initial Catalog=ForeignDB;User ID=foreign;Password=Aa@1234567891011;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("foreign")
            .UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<AgentStatusTbl>(entity =>
        {
            entity.HasKey(e => e.AgentStatusId);

            entity.ToTable("AgentStatusTbl", "dbo");

            entity.Property(e => e.AgentStatusId)
                .ValueGeneratedNever()
                .HasColumnName("AgentStatusID");
            entity.Property(e => e.AgentStatusType).HasMaxLength(100);
        });

        modelBuilder.Entity<AgentTbl>(entity =>
        {
            entity.HasKey(e => e.AgentId);

            entity.ToTable("AgentTbl", "dbo");

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AgentFamily).HasMaxLength(100);
            entity.Property(e => e.AgentFatherName).HasMaxLength(100);
            entity.Property(e => e.AgentName).HasMaxLength(100);
            entity.Property(e => e.AgentStatusId).HasColumnName("AgentStatusID");
            entity.Property(e => e.BirthCertificateDate).HasMaxLength(10);
            entity.Property(e => e.BirthCertificateNumber).HasMaxLength(50);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CompanyName).HasMaxLength(300);
            entity.Property(e => e.DateOfBirth).HasMaxLength(10);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.Mobile).HasMaxLength(11);
            entity.Property(e => e.NationalCode).HasMaxLength(10);
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.Photo).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(10);
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");
            entity.Property(e => e.Subset).HasMaxLength(300);
            entity.Property(e => e.TypeOfEmploymentId).HasColumnName("TypeOfEmploymentID");
            entity.Property(e => e.TypeOfMissionId).HasColumnName("TypeOfMissionID");

            entity.HasOne(d => d.AgentStatus).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.AgentStatusId)
                .HasConstraintName("FK_AgentTbl_AgentStatusTbl");

            entity.HasOne(d => d.City).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_CityTbl");

            entity.HasOne(d => d.Position).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AgentTbl_PositionTypeTbl");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK_AgentTbl_SubCategoryTbl");

            entity.HasOne(d => d.TypeOfEmployment).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.TypeOfEmploymentId)
                .HasConstraintName("FK_AgentTbl_TypeOfEmploymentTbl");

            entity.HasOne(d => d.TypeOfMission).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.TypeOfMissionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_TypeOfMissionTbl");
        });

        modelBuilder.Entity<CityTbl>(entity =>
        {
            entity.HasKey(e => e.CityId);

            entity.ToTable("CityTbl", "dbo");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName).HasMaxLength(250);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");

            entity.HasOne(d => d.Country).WithMany(p => p.CityTbls)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CityTbl_CountryTbl");
        });

        modelBuilder.Entity<CountryTbl>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK_ProvinceTbl");

            entity.ToTable("CountryTbl", "dbo");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnName("CountryID");
            entity.Property(e => e.CountryName).HasMaxLength(250);
        });

        modelBuilder.Entity<DispatcherSelectionTbl>(entity =>
        {
            entity.HasKey(e => e.DispatcherSelectionId);

            entity.ToTable("DispatcherSelectionTbl", "dbo");

            entity.Property(e => e.DispatcherSelectionId).HasColumnName("DispatcherSelectionID");
            entity.Property(e => e.DispatcherSelectionType).HasMaxLength(300);
        });

        modelBuilder.Entity<ExpertSelectionTbl>(entity =>
        {
            entity.HasKey(e => e.ExpertSelectionId);

            entity.ToTable("ExpertSelectionTbl", "dbo");

            entity.Property(e => e.ExpertSelectionId).HasColumnName("ExpertSelectionID");
            entity.Property(e => e.ExpertSelectionType).HasMaxLength(200);
        });

        modelBuilder.Entity<FileDetailsTbl>(entity =>
        {
            entity.HasKey(e => e.FileId);

            entity.ToTable("FileDetailsTbl", "dbo");

            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.Date).HasMaxLength(10);
            entity.Property(e => e.FileName)
                .HasMaxLength(80)
                .IsFixedLength();
            entity.Property(e => e.FileTypeId).HasColumnName("FileTypeID");
            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");

            entity.HasOne(d => d.FileType).WithMany(p => p.FileDetailsTbls)
                .HasForeignKey(d => d.FileTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FileDetailsTbl_FileTypeTbl");

            entity.HasOne(d => d.Report).WithMany(p => p.FileDetailsTbls)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("FK_FileDetailsTbl_Report");

            entity.HasOne(d => d.Request).WithMany(p => p.FileDetailsTbls)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FileDetailsTbl_RequestTbl");
        });

        modelBuilder.Entity<FileTypeTbl>(entity =>
        {
            entity.HasKey(e => e.FileTypeId).HasName("PK_dbo.FileTypeTbl");

            entity.ToTable("FileTypeTbl", "dbo");

            entity.Property(e => e.FileTypeId).HasColumnName("FileTypeID");
            entity.Property(e => e.FileTypeTitle).HasMaxLength(300);
        });

        modelBuilder.Entity<ForeignDelegrationTbl>(entity =>
        {
            entity.HasKey(e => e.ForeignDelegationId).HasName("PK_ForeginDelegration");

            entity.ToTable("ForeignDelegrationTbl", "dbo");

            entity.Property(e => e.ForeignDelegationId)
                .ValueGeneratedNever()
                .HasColumnName("ForeignDelegationID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.DateOfBirth).HasMaxLength(10);
            entity.Property(e => e.DateOfIssue).HasMaxLength(10);
            entity.Property(e => e.DurationOfStayInIran).HasMaxLength(300);
            entity.Property(e => e.EmailAddress).HasMaxLength(300);
            entity.Property(e => e.ExpiryDate).HasMaxLength(10);
            entity.Property(e => e.FatherSName)
                .HasMaxLength(300)
                .HasColumnName("Father'sName");
            entity.Property(e => e.HostLandlineNumber).HasMaxLength(11);
            entity.Property(e => e.HostMobileNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.HostName).HasMaxLength(300);
            entity.Property(e => e.LandlineNumber).HasMaxLength(20);
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Nationality).HasMaxLength(100);
            entity.Property(e => e.Occupation).HasMaxLength(300);
            entity.Property(e => e.Organization).HasMaxLength(300);
            entity.Property(e => e.PlaceOfBirth).HasMaxLength(100);
            entity.Property(e => e.PlaceOfIssue).HasMaxLength(300);
            entity.Property(e => e.PlaceVisaToBeIssued).HasMaxLength(300);
            entity.Property(e => e.Sex).HasMaxLength(10);
            entity.Property(e => e.SurName).HasMaxLength(300);
            entity.Property(e => e.ThePreviouseDateOfEntryToIran).HasMaxLength(10);
            entity.Property(e => e.TypeOfPassport).HasMaxLength(300);

            entity.HasOne(d => d.City).WithMany(p => p.ForeignDelegrationTbls)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_ForeginDelegrationTbl_CityTbl");
        });

        modelBuilder.Entity<GenderTypeTbl>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK_GenderType");

            entity.ToTable("GenderTypeTbl", "dbo");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GenderType).HasMaxLength(100);
        });

        modelBuilder.Entity<InfoTbl>(entity =>
        {
            entity.HasKey(e => e.InfoId).HasName("PK_RuleTbl");

            entity.ToTable("InfoTbl", "dbo");

            entity.Property(e => e.InfoId).HasColumnName("InfoID");
        });

        modelBuilder.Entity<InternationalAdminTbl>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK_AdminTbl");

            entity.ToTable("InternationalAdminTbl", "dbo");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AdminName).HasMaxLength(100);
            entity.Property(e => e.AdminUsername).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(5);
        });

        modelBuilder.Entity<InternationalExpertTbl>(entity =>
        {
            entity.HasKey(e => e.InternationalExpertId);

            entity.ToTable("InternationalExpertTbl", "dbo");

            entity.Property(e => e.InternationalExpertId).HasColumnName("InternationalExpertID");
            entity.Property(e => e.InternationalExpertFamily).HasMaxLength(300);
            entity.Property(e => e.InternationalExpertName).HasMaxLength(300);
            entity.Property(e => e.InternationalExpertUserName).HasMaxLength(300);
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(5);
        });

        modelBuilder.Entity<JobGoalsTypeTbl>(entity =>
        {
            entity.HasKey(e => e.JobGoalsId).HasName("PK_JobGoalsType");

            entity.ToTable("JobGoalsTypeTbl", "dbo");

            entity.Property(e => e.JobGoalsId).HasColumnName("JobGoalsID");
            entity.Property(e => e.JobGoalsType).HasMaxLength(50);
        });

        modelBuilder.Entity<LanguageTypeTbl>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK_languageType");

            entity.ToTable("LanguageTypeTbl", "dbo");

            entity.Property(e => e.LanguageId).HasColumnName("languageID");
            entity.Property(e => e.LanguageType)
                .HasMaxLength(100)
                .HasColumnName("languageType");
        });

        modelBuilder.Entity<LoginTbl>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.ToTable("LoginTbl", "dbo");

            entity.Property(e => e.LoginId).HasColumnName("LoginID");
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Date).HasMaxLength(10);
            entity.Property(e => e.InternationalExpertId).HasColumnName("InternationalExpertID");
            entity.Property(e => e.MainAdminId).HasColumnName("MainAdminID");
            entity.Property(e => e.SupervisorId).HasColumnName("SupervisorID");
            entity.Property(e => e.Time).HasMaxLength(10);

            entity.HasOne(d => d.Admin).WithMany(p => p.LoginTbls)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LoginTbl_InternationalAdminTbl");

            entity.HasOne(d => d.Agent).WithMany(p => p.LoginTbls)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LoginTbl_AgentTbl");

            entity.HasOne(d => d.InternationalExpert).WithMany(p => p.LoginTbls)
                .HasForeignKey(d => d.InternationalExpertId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LoginTbl_InternationalExpertTbl");

            entity.HasOne(d => d.MainAdmin).WithMany(p => p.LoginTbls)
                .HasForeignKey(d => d.MainAdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LoginTbl_MainAdminTbl");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.LoginTbls)
                .HasForeignKey(d => d.SupervisorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LoginTbl_SupervisorTbl");
        });

        modelBuilder.Entity<MainAdminTbl>(entity =>
        {
            entity.HasKey(e => e.MainAdminId).HasName("PK_SupervisorAdmin");

            entity.ToTable("MainAdminTbl", "dbo");

            entity.Property(e => e.MainAdminId).HasColumnName("MainAdminID");
            entity.Property(e => e.MainAdminName).HasMaxLength(100);
            entity.Property(e => e.MainAdminUserName).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(5);
        });

        modelBuilder.Entity<MaritalStatusTbl>(entity =>
        {
            entity.HasKey(e => e.MaritalStatusId);

            entity.ToTable("MaritalStatusTbl", "dbo");

            entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");
            entity.Property(e => e.MaritalStatusTitle).HasMaxLength(300);
        });

        modelBuilder.Entity<MessageTbl>(entity =>
        {
            entity.HasKey(e => e.MessageId);

            entity.ToTable("MessageTbl", "dbo");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.DispatcherSelectionId).HasColumnName("DispatcherSelectionID");
            entity.Property(e => e.ExpertSelectionId).HasColumnName("ExpertSelectionID");
            entity.Property(e => e.MessageText).HasMaxLength(500);
            entity.Property(e => e.MessageTopic).HasMaxLength(300);
            entity.Property(e => e.ReciverMessageId).HasColumnName("ReciverMessageID");
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(10);
            entity.Property(e => e.SubmitTime).HasMaxLength(50);

            entity.HasOne(d => d.Agent).WithMany(p => p.MessageTbls)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_MessageTbl_AgentTbl");

            entity.HasOne(d => d.DispatcherSelection).WithMany(p => p.MessageTbls)
                .HasForeignKey(d => d.DispatcherSelectionId)
                .HasConstraintName("FK_MessageTbl_DispatcherSelectionTbl");

            entity.HasOne(d => d.ExpertSelection).WithMany(p => p.MessageTbls)
                .HasForeignKey(d => d.ExpertSelectionId)
                .HasConstraintName("FK_MessageTbl_ExpertSelectionTbl");

            entity.HasOne(d => d.ReciverMessage).WithMany(p => p.MessageTbls)
                .HasForeignKey(d => d.ReciverMessageId)
                .HasConstraintName("FK_MessageTbl_MessageTbl");
        });

        modelBuilder.Entity<OperationTypeTbl>(entity =>
        {
            entity.HasKey(e => e.OperationId).HasName("PK_OperationTbl");

            entity.ToTable("OperationTypeTbl", "dbo");

            entity.Property(e => e.OperationId).HasColumnName("OperationID");
            entity.Property(e => e.OperationType).HasMaxLength(100);
        });

        modelBuilder.Entity<ParticipantTbl>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("PK_DeviceNameIType");

            entity.ToTable("ParticipantTbl", "dbo");

            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.DeviceNameType).HasMaxLength(100);
        });

        modelBuilder.Entity<PassportTbl>(entity =>
        {
            entity.HasKey(e => e.PassportId);

            entity.ToTable("PassportTbl", "dbo");

            entity.Property(e => e.PassportId)
                .ValueGeneratedNever()
                .HasColumnName("PassportID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.DegreeOfEducation).HasMaxLength(50);
            entity.Property(e => e.DispatchingAgency).HasMaxLength(200);
            entity.Property(e => e.FarsiFamily).HasMaxLength(300);
            entity.Property(e => e.FarsiFatherName).HasMaxLength(100);
            entity.Property(e => e.FarsiName).HasMaxLength(300);
            entity.Property(e => e.LatinFamily).HasMaxLength(300);
            entity.Property(e => e.LatinFatherName).HasMaxLength(300);
            entity.Property(e => e.LatinName).HasMaxLength(300);
            entity.Property(e => e.MaritalStatus).HasMaxLength(10);
            entity.Property(e => e.MissionLocation).HasMaxLength(300);
            entity.Property(e => e.TypeOfMission).HasMaxLength(10);
        });

        modelBuilder.Entity<PassportTypeTbl>(entity =>
        {
            entity.HasKey(e => e.PassportTypeId).HasName("PK_PassportType");

            entity.ToTable("PassportTypeTbl", "dbo");

            entity.Property(e => e.PassportTypeId).HasColumnName("PassportTypeID");
            entity.Property(e => e.PassportType).HasMaxLength(50);
        });

        modelBuilder.Entity<PositionTypeTbl>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK_PositionTbl");

            entity.ToTable("PositionTypeTbl", "dbo");

            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.PositionType).HasMaxLength(100);
        });

        modelBuilder.Entity<ReciverMessageTbl>(entity =>
        {
            entity.HasKey(e => e.ReciverMessageId);

            entity.ToTable("ReciverMessageTbl", "dbo");

            entity.Property(e => e.ReciverMessageId).HasColumnName("ReciverMessageID");
            entity.Property(e => e.ReciverMessageType).HasMaxLength(100);
        });

        modelBuilder.Entity<ReportStatusTbl>(entity =>
        {
            entity.HasKey(e => e.ReportStatusId);

            entity.ToTable("ReportStatusTbl", "dbo");

            entity.Property(e => e.ReportStatusId).HasColumnName("ReportStatusID");
            entity.Property(e => e.ReportStatusType).HasMaxLength(200);
        });

        modelBuilder.Entity<ReportTbl>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK_Report");

            entity.ToTable("ReportTbl", "dbo");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.EmailExternalDevice).HasMaxLength(100);
            entity.Property(e => e.EmailInternalDevice).HasMaxLength(100);
            entity.Property(e => e.ExternalDevice).HasMaxLength(100);
            entity.Property(e => e.InternalDevice).HasMaxLength(100);
            entity.Property(e => e.LatestUpdate)
                .HasMaxLength(200)
                .HasColumnName("latestUpdate");
            entity.Property(e => e.LicenseDate).HasMaxLength(100);
            entity.Property(e => e.LicenseNumber).HasMaxLength(100);
            entity.Property(e => e.Period).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(10);
            entity.Property(e => e.ReportAchievement).HasDefaultValueSql("('NULL')");
            entity.Property(e => e.ReportStatusId).HasColumnName("ReportStatusID");
            entity.Property(e => e.RequestDateNumber).HasMaxLength(100);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");

            entity.HasOne(d => d.ReportStatus).WithMany(p => p.ReportTbls)
                .HasForeignKey(d => d.ReportStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Report_ReportStatusTbl");

            entity.HasOne(d => d.Request).WithMany(p => p.ReportTbls)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Report_RequestTbl");
        });

        modelBuilder.Entity<RequestEmployeeTbl>(entity =>
        {
            entity.HasKey(e => e.RequestEmployeeId).HasName("PK__RequestE__7AD04F11A41FDFF4");

            entity.ToTable("RequestEmployeeTbl", "dbo");

            entity.Property(e => e.RequestEmployeeId).HasColumnName("RequestEmployeeID");
            entity.Property(e => e.BirthCertificationDate)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.BirthCertificationNumber).HasMaxLength(100);
            entity.Property(e => e.Degree).HasMaxLength(50);
            entity.Property(e => e.EmployeeFamily).HasMaxLength(200);
            entity.Property(e => e.EmployeeFatherName).HasMaxLength(200);
            entity.Property(e => e.EmployeeName).HasMaxLength(200);
            entity.Property(e => e.EmployeeStatus)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.FieldOfStudy).HasMaxLength(200);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.JobLocation)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");
            entity.Property(e => e.Mobile).HasMaxLength(15);
            entity.Property(e => e.NationalCode).HasMaxLength(100);
            entity.Property(e => e.PassPortTypeId).HasColumnName("PassPortTypeID");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.WorkExperience)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.Gender).WithMany(p => p.RequestEmployeeTbls)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_RequestEmployeeTbl_GenderTypeTbl");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.RequestEmployeeTbls)
                .HasForeignKey(d => d.MaritalStatusId)
                .HasConstraintName("FK_RequestEmployeeTbl_MaritalStatusTbl");

            entity.HasOne(d => d.PassPortType).WithMany(p => p.RequestEmployeeTbls)
                .HasForeignKey(d => d.PassPortTypeId)
                .HasConstraintName("FK_RequestEmployeeTbl_PassportTypeTbl");

            entity.HasOne(d => d.Position).WithMany(p => p.RequestEmployeeTbls)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_RequestEmployeeTbl_PositionTypeTbl");
        });

        modelBuilder.Entity<RequestStatusTbl>(entity =>
        {
            entity.HasKey(e => e.RequestStatusId);

            entity.ToTable("RequestStatusTbl", "dbo");

            entity.Property(e => e.RequestStatusId).HasColumnName("RequestStatusID");
            entity.Property(e => e.RequestStatusTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<RequestTbl>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("RequestTbl", "dbo");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.AirlineCompany).HasMaxLength(100);
            entity.Property(e => e.AmountOfCost).HasMaxLength(100);
            entity.Property(e => e.ApprovedBy).HasMaxLength(300);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CostOfFood).HasMaxLength(100);
            entity.Property(e => e.DateLetter).HasMaxLength(200);
            entity.Property(e => e.DateOfLasteChange).HasMaxLength(100);
            entity.Property(e => e.DeviceName).HasMaxLength(100);
            entity.Property(e => e.EmployeeStatus).HasMaxLength(200);
            entity.Property(e => e.ExecutiveDeviceName).HasMaxLength(100);
            entity.Property(e => e.ExpertRightOfMission).HasMaxLength(100);
            entity.Property(e => e.FlightPath).HasMaxLength(200);
            entity.Property(e => e.ForeignTravelSummary).HasMaxLength(500);
            entity.Property(e => e.GeneralManagerRightOfMission).HasMaxLength(100);
            entity.Property(e => e.ImportantTravel).HasMaxLength(500);
            entity.Property(e => e.InternationalExpertId).HasColumnName("InternationalExpertID");
            entity.Property(e => e.InternetAddressOfTheExecutiveDevice).HasMaxLength(100);
            entity.Property(e => e.JobGoalId)
                .HasMaxLength(50)
                .HasColumnName("JobGoalID");
            entity.Property(e => e.MainAdminId).HasColumnName("MainAdminID");
            entity.Property(e => e.ManagerRightOfMission).HasMaxLength(100);
            entity.Property(e => e.MissionAchievementRecords).HasMaxLength(500);
            entity.Property(e => e.OperationId).HasMaxLength(100);
            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.PassportTypeId)
                .HasMaxLength(50)
                .HasColumnName("PassportTypeID");
            entity.Property(e => e.PayerCitizenShip).HasMaxLength(100);
            entity.Property(e => e.PayerFood).HasMaxLength(100);
            entity.Property(e => e.PaymentFromBank).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(10);
            entity.Property(e => e.RejectRequest).HasMaxLength(500);
            entity.Property(e => e.RequestStatusId).HasColumnName("RequestStatusID");
            entity.Property(e => e.RightOfCommutingExternalCost).HasMaxLength(100);
            entity.Property(e => e.RightOfCommutingId)
                .HasMaxLength(50)
                .HasColumnName("RightOfCommutingID");
            entity.Property(e => e.RightOfCommutingInternalDeviceCost).HasMaxLength(100);
            entity.Property(e => e.RightOfCommutingPersonCost).HasMaxLength(100);
            entity.Property(e => e.RightOfMissionId)
                .HasMaxLength(50)
                .HasColumnName("RightOfMissionID");
            entity.Property(e => e.RightToEducationApplicantCost).HasMaxLength(100);
            entity.Property(e => e.RightToEducationId)
                .HasMaxLength(50)
                .HasColumnName("RightToEducationID");
            entity.Property(e => e.RightToEducationInternalDeviceCost).HasMaxLength(100);
            entity.Property(e => e.SummaryInvitation).HasMaxLength(500);
            entity.Property(e => e.TheCostOfTicket).HasMaxLength(100);
            entity.Property(e => e.TickerTypeId)
                .HasMaxLength(100)
                .HasColumnName("TickerTypeID");
            entity.Property(e => e.TicketCost).HasMaxLength(100);
            entity.Property(e => e.TollAmountDeviceCost).HasMaxLength(100);
            entity.Property(e => e.TollAmountId).HasColumnName("TollAmountID");
            entity.Property(e => e.TollAmountPersonCost).HasMaxLength(100);
            entity.Property(e => e.TravalEndDate).HasMaxLength(50);
            entity.Property(e => e.TravelDateStart).HasMaxLength(50);
            entity.Property(e => e.TravelGoalId)
                .HasMaxLength(50)
                .HasColumnName("TravelGoalID");
            entity.Property(e => e.TravelTime).HasMaxLength(5);
            entity.Property(e => e.TravelTopic).HasMaxLength(300);
            entity.Property(e => e.TypeAccommodationId).HasColumnName("TypeAccommodationID");
            entity.Property(e => e.VisaCost).HasMaxLength(100);

            entity.HasOne(d => d.Admin).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_InternationalAdminTbl");

            entity.HasOne(d => d.Agent).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_AgentTbl");

            entity.HasOne(d => d.City).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_RequestTbl_CityTbl");

            entity.HasOne(d => d.InternationalExpert).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.InternationalExpertId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_InternationalExpertTbl");

            entity.HasOne(d => d.MainAdmin).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.MainAdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_MainAdminTbl");

            entity.HasOne(d => d.Participant).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestTbl_DeviceNameITypeTbl");

            entity.HasOne(d => d.RequestStatus).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.RequestStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_RequestStatusTbl");

            entity.HasOne(d => d.TollAmount).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.TollAmountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_TollAmountTypeTbl");

            entity.HasOne(d => d.TravelType).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.TravelTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_TravelTypeTbl");

            entity.HasOne(d => d.TypeAccommodation).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.TypeAccommodationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RequestTbl_TypeAccommodationID");
        });

        modelBuilder.Entity<RightOfCommutingTypeTbl>(entity =>
        {
            entity.HasKey(e => e.RightOfCommutingId);

            entity.ToTable("RightOfCommutingTypeTbl", "dbo");

            entity.Property(e => e.RightOfCommutingId).HasColumnName("RightOfCommutingID");
            entity.Property(e => e.RightOfCommutingType).HasMaxLength(100);
        });

        modelBuilder.Entity<RightOfMissionTbl>(entity =>
        {
            entity.HasKey(e => e.RightOfMissionId).HasName("PK_RightOfMission");

            entity.ToTable("RightOfMissionTbl", "dbo");

            entity.Property(e => e.RightOfMissionId).HasColumnName("RightOfMissionID");
            entity.Property(e => e.RightOfMissionType).HasMaxLength(100);
        });

        modelBuilder.Entity<RightToEducationTbl>(entity =>
        {
            entity.HasKey(e => e.RightToEducationId).HasName("PK_RightToEducation");

            entity.ToTable("RightToEducationTbl", "dbo");

            entity.Property(e => e.RightToEducationId).HasColumnName("RightToEducationID");
            entity.Property(e => e.RightToEducationType).HasMaxLength(100);
        });

        modelBuilder.Entity<SignatureRequestTbl>(entity =>
        {
            entity.HasKey(e => e.SignutureId).HasName("PK__Signatur__9E5896E5C8363817");

            entity.ToTable("SignatureRequestTbl", "dbo");

            entity.Property(e => e.SignutureId).HasColumnName("SignutureID");
            entity.Property(e => e.FileName).HasMaxLength(100);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.Signatory).HasMaxLength(100);

            entity.HasOne(d => d.Request).WithMany(p => p.SignatureRequestTbls)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_SignatureRequestTbl_RequestTbl");
        });

        modelBuilder.Entity<SubCategoryTbl>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId);

            entity.ToTable("SubCategoryTbl", "dbo");

            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");
            entity.Property(e => e.SubCategoryType).HasMaxLength(100);
        });

        modelBuilder.Entity<SubsidiaryOrganizationTypeTbl>(entity =>
        {
            entity.HasKey(e => e.SubsidiaryOrganizationId).HasName("PK_SubsidiaryOrganization");

            entity.ToTable("SubsidiaryOrganizationTypeTbl", "dbo");

            entity.Property(e => e.SubsidiaryOrganizationId).HasColumnName("SubsidiaryOrganizationID");
            entity.Property(e => e.SubsidiaryOrganizationType).HasMaxLength(100);
        });

        modelBuilder.Entity<SupervisorTbl>(entity =>
        {
            entity.HasKey(e => e.SupervisorId).HasName("PK_OverseerTbl");

            entity.ToTable("SupervisorTbl", "dbo");

            entity.Property(e => e.SupervisorId).HasColumnName("SupervisorID");
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(10);
            entity.Property(e => e.SupervisorFamily).HasMaxLength(100);
            entity.Property(e => e.SupervisorName).HasMaxLength(100);
            entity.Property(e => e.SupervisorUserName)
                .HasMaxLength(100)
                .HasColumnName("SupervisorUSerName");
        });

        modelBuilder.Entity<TicketDetailsTbl>(entity =>
        {
            entity.HasKey(e => e.TicketDetailId).HasName("PK__TicketDe__39BFBDC6395FE87E");

            entity.ToTable("TicketDetailsTbl", "dbo");

            entity.Property(e => e.TicketDetailId).HasColumnName("TicketDetailID");
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(10);
            entity.Property(e => e.TicketId).HasColumnName("TicketID");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketDetailsTbls)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK_TicketDetailsTbl_TicketTbl");
        });

        modelBuilder.Entity<TicketStatusTbl>(entity =>
        {
            entity.HasKey(e => e.TicketStatusId);

            entity.ToTable("TicketStatusTbl", "dbo");

            entity.Property(e => e.TicketStatusId).HasColumnName("TicketStatusID");
            entity.Property(e => e.TicketStatusTitle).HasMaxLength(100);
        });

        modelBuilder.Entity<TicketTbl>(entity =>
        {
            entity.HasKey(e => e.TicketId);

            entity.ToTable("TicketTbl", "dbo");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.InternationalExpertId).HasColumnName("InternationalExpertID");
            entity.Property(e => e.LatestUpdate)
                .HasMaxLength(100)
                .HasColumnName("latestUpdate");
            entity.Property(e => e.MainAdminId).HasColumnName("MainAdminID");
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(8);
            entity.Property(e => e.TicketNumber).HasMaxLength(100);
            entity.Property(e => e.TicketStatusId).HasColumnName("TicketStatusID");

            entity.HasOne(d => d.Admin).WithMany(p => p.TicketTbls)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TicketTbl_InternationalAdminTbl");

            entity.HasOne(d => d.Agent).WithMany(p => p.TicketTbls)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TicketTbl_AgentTbl");

            entity.HasOne(d => d.InternationalExpert).WithMany(p => p.TicketTbls)
                .HasForeignKey(d => d.InternationalExpertId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TicketTbl_InternationalExpertTbl");

            entity.HasOne(d => d.MainAdmin).WithMany(p => p.TicketTbls)
                .HasForeignKey(d => d.MainAdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TicketTbl_MainAdminTbl");

            entity.HasOne(d => d.TicketStatus).WithMany(p => p.TicketTbls)
                .HasForeignKey(d => d.TicketStatusId)
                .HasConstraintName("FK_TicketTbl_TicketStatusTbl");
        });

        modelBuilder.Entity<TicketTypeTbl>(entity =>
        {
            entity.HasKey(e => e.TicketTypeId).HasName("PK_TicketType");

            entity.ToTable("TicketTypeTbl", "dbo");

            entity.Property(e => e.TicketTypeId).HasColumnName("TicketTypeID");
            entity.Property(e => e.TicketType).HasMaxLength(100);
        });

        modelBuilder.Entity<TollAmountTypeTbl>(entity =>
        {
            entity.HasKey(e => e.TollAmountId);

            entity.ToTable("TollAmountTypeTbl", "dbo");

            entity.Property(e => e.TollAmountId).HasColumnName("TollAmountID");
            entity.Property(e => e.TollAmountType).HasMaxLength(100);
        });

        modelBuilder.Entity<TravelGoalsTypeTbl>(entity =>
        {
            entity.HasKey(e => e.TravelGoalsId).HasName("PK_TravelGoalsType");

            entity.ToTable("TravelGoalsTypeTbl", "dbo");

            entity.Property(e => e.TravelGoalsId).HasColumnName("TravelGoalsID");
            entity.Property(e => e.TravelGoalsType).HasMaxLength(100);
        });

        modelBuilder.Entity<TravelTypeTbl>(entity =>
        {
            entity.HasKey(e => e.TravelTypeId);

            entity.ToTable("TravelTypeTbl", "dbo");

            entity.Property(e => e.TravelType).HasMaxLength(50);
        });

        modelBuilder.Entity<TypeAccommodationTbl>(entity =>
        {
            entity.HasKey(e => e.TypeAccommodationId).HasName("PK__TypeAcco__06295C7CFFC2D802");

            entity.ToTable("TypeAccommodationTbl", "dbo");

            entity.Property(e => e.TypeAccommodationId).HasColumnName("TypeAccommodationID");
            entity.Property(e => e.TypeAccommodationType).HasMaxLength(100);
        });

        modelBuilder.Entity<TypeOfEmploymentTbl>(entity =>
        {
            entity.HasKey(e => e.TypeOfEmploymentId);

            entity.ToTable("TypeOfEmploymentTbl", "dbo");

            entity.Property(e => e.TypeOfEmploymentId).HasColumnName("TypeOfEmploymentID");
            entity.Property(e => e.TypeOfEmploymentTitle).HasMaxLength(300);
        });

        modelBuilder.Entity<TypeOfMissionTbl>(entity =>
        {
            entity.HasKey(e => e.TypeOfMissionId).HasName("PK_TypeOfMission");

            entity.ToTable("TypeOfMissionTbl", "dbo");

            entity.Property(e => e.TypeOfMissionId).HasColumnName("TypeOfMissionID");
            entity.Property(e => e.TypeOfMissionTitle).HasMaxLength(300);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
