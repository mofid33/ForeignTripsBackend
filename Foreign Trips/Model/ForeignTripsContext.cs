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

    public virtual DbSet<AgentStatusTbl> AgentStatusTbls { get; set; }

    public virtual DbSet<AgentTbl> AgentTbls { get; set; }

    public virtual DbSet<CityTbl> CityTbls { get; set; }

    public virtual DbSet<DeviceNameItypeTbl> DeviceNameItypeTbls { get; set; }

    public virtual DbSet<FileDetailsTbl> FileDetailsTbls { get; set; }

    public virtual DbSet<FileTypeTbl> FileTypeTbls { get; set; }

    public virtual DbSet<ForeignDelegrationTbl> ForeignDelegrationTbls { get; set; }

    public virtual DbSet<GenderTypeTbl> GenderTypeTbls { get; set; }

    public virtual DbSet<InternationalExpertTbl> InternationalExpertTbls { get; set; }

    public virtual DbSet<JobGoalsTypeTbl> JobGoalsTypeTbls { get; set; }

    public virtual DbSet<LanguageType> LanguageTypes { get; set; }

    public virtual DbSet<LoginTbl> LoginTbls { get; set; }

    public virtual DbSet<MaritalStatusTbl> MaritalStatusTbls { get; set; }

    public virtual DbSet<OverseerTbl> OverseerTbls { get; set; }

    public virtual DbSet<PassportTbl> PassportTbls { get; set; }

    public virtual DbSet<PassportType> PassportTypes { get; set; }

    public virtual DbSet<PositionTypeTbl> PositionTypeTbls { get; set; }

    public virtual DbSet<ProvinceTbl> ProvinceTbls { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<RequestStatusTbl> RequestStatusTbls { get; set; }

    public virtual DbSet<RequestTbl> RequestTbls { get; set; }

    public virtual DbSet<RightOfCommutingTypeTbl> RightOfCommutingTypeTbls { get; set; }

    public virtual DbSet<RightOfMissionTbl> RightOfMissionTbls { get; set; }

    public virtual DbSet<RightToEducationTbl> RightToEducationTbls { get; set; }

    public virtual DbSet<RuleTbl> RuleTbls { get; set; }

    public virtual DbSet<SubsidiaryOrganizationTypeTbl> SubsidiaryOrganizationTypeTbls { get; set; }

    public virtual DbSet<SupervisoerTbl> SupervisoerTbls { get; set; }

    public virtual DbSet<TicketDetailsTbl> TicketDetailsTbls { get; set; }

    public virtual DbSet<TicketStatusTbl> TicketStatusTbls { get; set; }

    public virtual DbSet<TicketTbl> TicketTbls { get; set; }

    public virtual DbSet<TicketTypeTbl> TicketTypeTbls { get; set; }

    public virtual DbSet<TollAmountTypeTbl> TollAmountTypeTbls { get; set; }

    public virtual DbSet<TravelGoalsTypeTbl> TravelGoalsTypeTbls { get; set; }

    public virtual DbSet<TypeOfEmploymentTbl> TypeOfEmploymentTbls { get; set; }

    public virtual DbSet<TypeOfMissionTbl> TypeOfMissionTbls { get; set; }

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
            entity.Property(e => e.AdminName).HasMaxLength(100);
            entity.Property(e => e.AdminUsername).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(300);
        });

        modelBuilder.Entity<AgentStatusTbl>(entity =>
        {
            entity.HasKey(e => e.AgentStatusId);

            entity.ToTable("AgentStatusTbl");

            entity.Property(e => e.AgentStatusId)
                .ValueGeneratedNever()
                .HasColumnName("AgentStatusID");
            entity.Property(e => e.AgentStatusType).HasMaxLength(100);
        });

        modelBuilder.Entity<AgentTbl>(entity =>
        {
            entity.HasKey(e => e.AgentId);

            entity.ToTable("AgentTbl");

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AgentFamily).HasMaxLength(100);
            entity.Property(e => e.AgentName).HasMaxLength(100);
            entity.Property(e => e.AgentStatusId).HasColumnName("AgentStatusID");
            entity.Property(e => e.BirthCertificateDate).HasMaxLength(10);
            entity.Property(e => e.BirthCertificateNumber).HasMaxLength(50);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CompanyName).HasMaxLength(300);
            entity.Property(e => e.Degree).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FieldOfStudy).HasMaxLength(100);
            entity.Property(e => e.LanguageId)
                .HasMaxLength(50)
                .HasColumnName("languageID");
            entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");
            entity.Property(e => e.Mobile).HasMaxLength(11);
            entity.Property(e => e.NationalCode).HasMaxLength(10);
            entity.Property(e => e.Password).HasMaxLength(300);
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.Photo).HasColumnType("image");
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.PostalCode).HasMaxLength(100);
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(5);
            entity.Property(e => e.Servicelocation).HasMaxLength(200);
            entity.Property(e => e.SupervisorId).HasColumnName("SupervisorID");
            entity.Property(e => e.TypeOfEmploymentId).HasColumnName("TypeOfEmploymentID");
            entity.Property(e => e.TypeOfMissionId).HasColumnName("TypeOfMissionID");

            entity.HasOne(d => d.AgentStatus).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.AgentStatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_AgentStatusTbl");

            entity.HasOne(d => d.City).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_CityTbl");

            entity.HasOne(d => d.Gender).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_GenderType");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.MaritalStatusId)
                .HasConstraintName("FK_AgentTbl_MaritalStatusTbl");

            entity.HasOne(d => d.Position).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_PositionTbl");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.SupervisorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_SupervisoerTbl");

            entity.HasOne(d => d.TypeOfEmployment).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.TypeOfEmploymentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_TypeOfEmploymentTbl");

            entity.HasOne(d => d.TypeOfMission).WithMany(p => p.AgentTbls)
                .HasForeignKey(d => d.TypeOfMissionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AgentTbl_TypeOfMissionTbl");
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

        modelBuilder.Entity<DeviceNameItypeTbl>(entity =>
        {
            entity.HasKey(e => e.DeviceNameId).HasName("PK_DeviceNameIType");

            entity.ToTable("DeviceNameITypeTbl");

            entity.Property(e => e.DeviceNameId).HasColumnName("DeviceNameID");
            entity.Property(e => e.DeviceNameType).HasMaxLength(100);
        });

        modelBuilder.Entity<FileDetailsTbl>(entity =>
        {
            entity.HasKey(e => e.FileId);

            entity.ToTable("FileDetailsTbl");

            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.Date).HasMaxLength(10);
            entity.Property(e => e.FileName)
                .HasMaxLength(80)
                .IsFixedLength();
            entity.Property(e => e.FileTypeId).HasColumnName("FileTypeID");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");

            entity.HasOne(d => d.FileType).WithMany(p => p.FileDetailsTbls)
                .HasForeignKey(d => d.FileTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FileDetailsTbl_FileTypeTbl");

            entity.HasOne(d => d.Request).WithMany(p => p.FileDetailsTbls)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FileDetailsTbl_FileDetailsTbl");
        });

        modelBuilder.Entity<FileTypeTbl>(entity =>
        {
            entity.HasKey(e => e.FileTypeId).HasName("PK_dbo.FileTypeTbl");

            entity.ToTable("FileTypeTbl");

            entity.Property(e => e.FileTypeId).HasColumnName("FileTypeID");
            entity.Property(e => e.FileTypeTitle).HasMaxLength(300);
        });

        modelBuilder.Entity<ForeignDelegrationTbl>(entity =>
        {
            entity.HasKey(e => e.ForeignDelegationId).HasName("PK_ForeginDelegration");

            entity.ToTable("ForeignDelegrationTbl");

            entity.Property(e => e.ForeignDelegationId)
                .ValueGeneratedNever()
                .HasColumnName("ForeignDelegationID");
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

            entity.ToTable("GenderTypeTbl");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GenderType).HasMaxLength(100);
        });

        modelBuilder.Entity<InternationalExpertTbl>(entity =>
        {
            entity.HasKey(e => e.InternationalExpertId);

            entity.ToTable("InternationalExpertTbl");

            entity.Property(e => e.InternationalExpertId).HasColumnName("InternationalExpertID");
            entity.Property(e => e.InternationalExpertUserName).HasMaxLength(100);
        });

        modelBuilder.Entity<JobGoalsTypeTbl>(entity =>
        {
            entity.HasKey(e => e.JobGoalsId).HasName("PK_JobGoalsType");

            entity.ToTable("JobGoalsTypeTbl");

            entity.Property(e => e.JobGoalsId).HasColumnName("JobGoalsID");
            entity.Property(e => e.JobGoalsType).HasMaxLength(50);
        });

        modelBuilder.Entity<LanguageType>(entity =>
        {
            entity.HasKey(e => e.LanguageId);

            entity.ToTable("languageType");

            entity.Property(e => e.LanguageId).HasColumnName("languageID");
            entity.Property(e => e.LanguageType1)
                .HasMaxLength(100)
                .HasColumnName("languageType");
        });

        modelBuilder.Entity<LoginTbl>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.ToTable("LoginTbl");

            entity.Property(e => e.LoginId).HasColumnName("LoginID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Date).HasMaxLength(10);
            entity.Property(e => e.Time).HasMaxLength(10);
        });

        modelBuilder.Entity<MaritalStatusTbl>(entity =>
        {
            entity.HasKey(e => e.MaritalStatusId);

            entity.ToTable("MaritalStatusTbl");

            entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");
            entity.Property(e => e.MaritalStatusTitle).HasMaxLength(300);
        });

        modelBuilder.Entity<OverseerTbl>(entity =>
        {
            entity.HasKey(e => e.OverseerId);

            entity.ToTable("OverseerTbl");

            entity.Property(e => e.OverseerId).HasColumnName("OverseerID");
            entity.Property(e => e.OverseerUserName)
                .HasMaxLength(50)
                .HasColumnName("OverseerUSerName");
        });

        modelBuilder.Entity<PassportTbl>(entity =>
        {
            entity.HasKey(e => e.PassportId);

            entity.ToTable("PassportTbl");

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

        modelBuilder.Entity<PassportType>(entity =>
        {
            entity.ToTable("PassportType");

            entity.Property(e => e.PassportTypeId).HasColumnName("PassportTypeID");
            entity.Property(e => e.PassportType1)
                .HasMaxLength(50)
                .HasColumnName("PassportType");
        });

        modelBuilder.Entity<PositionTypeTbl>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK_PositionTbl");

            entity.ToTable("PositionTypeTbl");

            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.PositionType).HasMaxLength(100);
        });

        modelBuilder.Entity<ProvinceTbl>(entity =>
        {
            entity.HasKey(e => e.ProvinceId);

            entity.ToTable("ProvinceTbl");

            entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");
            entity.Property(e => e.ProvinceName).HasMaxLength(250);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.ToTable("Report");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.EmailExternalDevice).HasMaxLength(100);
            entity.Property(e => e.EmailInternalDevice).HasMaxLength(100);
            entity.Property(e => e.ExternalDevice).HasMaxLength(100);
            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.InternalDevice).HasMaxLength(100);
            entity.Property(e => e.LicenseDate).HasMaxLength(100);
            entity.Property(e => e.LicenseNumber).HasMaxLength(100);
            entity.Property(e => e.Period).HasMaxLength(100);
            entity.Property(e => e.RequestDateNumber).HasMaxLength(100);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.SubjectOfTravel).HasMaxLength(300);

            entity.HasOne(d => d.File).WithMany(p => p.Reports)
                .HasForeignKey(d => d.FileId)
                .HasConstraintName("FK_Report_FileDetailsTbl");

            entity.HasOne(d => d.Request).WithMany(p => p.Reports)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_Report_RequestTbl");
        });

        modelBuilder.Entity<RequestStatusTbl>(entity =>
        {
            entity.HasKey(e => e.RequestStatusId);

            entity.ToTable("RequestStatusTbl");

            entity.Property(e => e.RequestStatusId).HasColumnName("RequestStatusID");
            entity.Property(e => e.RequestStatusTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<RequestTbl>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("RequestTbl");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.AirlineCompany).HasMaxLength(100);
            entity.Property(e => e.AmountOfCost).HasMaxLength(100);
            entity.Property(e => e.DestinationCity).HasMaxLength(100);
            entity.Property(e => e.DestinationCountry).HasMaxLength(100);
            entity.Property(e => e.DeviceNameId).HasColumnName("DeviceNameID");
            entity.Property(e => e.ExecutiveDeviceName).HasMaxLength(100);
            entity.Property(e => e.ExpertRightOfMission).HasMaxLength(100);
            entity.Property(e => e.FlightPath).HasMaxLength(200);
            entity.Property(e => e.ForeignTravelSummary).HasMaxLength(100);
            entity.Property(e => e.ImportantTravel).HasMaxLength(100);
            entity.Property(e => e.InternetAddressOfTheExecutiveDevice).HasMaxLength(100);
            entity.Property(e => e.JobGoalId).HasColumnName("JobGoalID");
            entity.Property(e => e.ManagerRightOfMission).HasMaxLength(100);
            entity.Property(e => e.MissionAchievementRecords).HasMaxLength(100);
            entity.Property(e => e.PassportTypeId).HasColumnName("PassportTypeID");
            entity.Property(e => e.PayerCitizenShip).HasMaxLength(100);
            entity.Property(e => e.PayerFood).HasMaxLength(100);
            entity.Property(e => e.PaymentFromBank).HasMaxLength(100);
            entity.Property(e => e.RequestStatusId).HasColumnName("RequestStatusID");
            entity.Property(e => e.RightOfCommutingCost).HasMaxLength(100);
            entity.Property(e => e.RightOfCommutingId).HasColumnName("RightOfCommutingID");
            entity.Property(e => e.RightOfMissionId).HasColumnName("RightOfMissionID");
            entity.Property(e => e.RightToEducationCost).HasMaxLength(100);
            entity.Property(e => e.RightToEducationId)
                .HasMaxLength(100)
                .HasColumnName("RightToEducationID");
            entity.Property(e => e.SummaryInvitation).HasMaxLength(100);
            entity.Property(e => e.TheCostOfFood).HasMaxLength(100);
            entity.Property(e => e.TheCostOfTicket).HasMaxLength(100);
            entity.Property(e => e.TickerTypeId)
                .HasMaxLength(100)
                .HasColumnName("TickerTypeID");
            entity.Property(e => e.TicketCost).HasMaxLength(100);
            entity.Property(e => e.TollAmountCost).HasMaxLength(100);
            entity.Property(e => e.TollAmountId).HasColumnName("TollAmountID");
            entity.Property(e => e.TravelDate).HasMaxLength(50);
            entity.Property(e => e.TravelGoalId).HasColumnName("TravelGoalID");
            entity.Property(e => e.TravelTime).HasMaxLength(5);
            entity.Property(e => e.TravelTopic).HasMaxLength(300);
            entity.Property(e => e.VisaCost).HasMaxLength(100);

            entity.HasOne(d => d.Agent).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_RequestTbl_AgentTbl");

            entity.HasOne(d => d.DeviceName).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.DeviceNameId)
                .HasConstraintName("FK_RequestTbl_DeviceNameITypeTbl");

            entity.HasOne(d => d.JobGoal).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.JobGoalId)
                .HasConstraintName("FK_RequestTbl_JobGoalsTypeTbl");

            entity.HasOne(d => d.PassportType).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.PassportTypeId)
                .HasConstraintName("FK_RequestTbl_PassportType");

            entity.HasOne(d => d.RequestStatus).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.RequestStatusId)
                .HasConstraintName("FK_RequestTbl_RequestTbl");

            entity.HasOne(d => d.RightOfCommuting).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.RightOfCommutingId)
                .HasConstraintName("FK_RequestTbl_RightOfCommutingTypeTbl");

            entity.HasOne(d => d.RightOfMission).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.RightOfMissionId)
                .HasConstraintName("FK_RequestTbl_RightOfMissionTbl");

            entity.HasOne(d => d.TollAmount).WithMany(p => p.RequestTbls)
                .HasForeignKey(d => d.TollAmountId)
                .HasConstraintName("FK_RequestTbl_TollAmountTypeTbl");
        });

        modelBuilder.Entity<RightOfCommutingTypeTbl>(entity =>
        {
            entity.HasKey(e => e.RightOfCommutingId);

            entity.ToTable("RightOfCommutingTypeTbl");

            entity.Property(e => e.RightOfCommutingId).HasColumnName("RightOfCommutingID");
            entity.Property(e => e.RightOfCommutingType).HasMaxLength(100);
        });

        modelBuilder.Entity<RightOfMissionTbl>(entity =>
        {
            entity.HasKey(e => e.RightOfMissionId).HasName("PK_RightOfMission");

            entity.ToTable("RightOfMissionTbl");

            entity.Property(e => e.RightOfMissionId).HasColumnName("RightOfMissionID");
            entity.Property(e => e.RightOfMissionType).HasMaxLength(100);
        });

        modelBuilder.Entity<RightToEducationTbl>(entity =>
        {
            entity.HasKey(e => e.RightToEducationId).HasName("PK_RightToEducation");

            entity.ToTable("RightToEducationTbl");

            entity.Property(e => e.RightToEducationId).HasColumnName("RightToEducationID");
            entity.Property(e => e.RightToEducationType).HasMaxLength(100);
        });

        modelBuilder.Entity<RuleTbl>(entity =>
        {
            entity.HasKey(e => e.RuleId);

            entity.ToTable("RuleTbl");

            entity.Property(e => e.RuleId)
                .ValueGeneratedNever()
                .HasColumnName("RuleID");
        });

        modelBuilder.Entity<SubsidiaryOrganizationTypeTbl>(entity =>
        {
            entity.HasKey(e => e.SubsidiaryOrganizationId).HasName("PK_SubsidiaryOrganization");

            entity.ToTable("SubsidiaryOrganizationTypeTbl");

            entity.Property(e => e.SubsidiaryOrganizationId).HasColumnName("SubsidiaryOrganizationID");
            entity.Property(e => e.SubsidiaryOrganizationType).HasMaxLength(100);
        });

        modelBuilder.Entity<SupervisoerTbl>(entity =>
        {
            entity.HasKey(e => e.SupervisorId).HasName("PK_SupervisorAdmin");

            entity.ToTable("SupervisoerTbl");

            entity.Property(e => e.SupervisorId).HasColumnName("SupervisorID");
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Password).HasMaxLength(300);
            entity.Property(e => e.SupervisorName).HasMaxLength(100);
            entity.Property(e => e.SupervisorUserName).HasMaxLength(100);

            entity.HasOne(d => d.Admin).WithMany(p => p.SupervisoerTbls)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SupervisorTbl_AdminTbl");
        });

        modelBuilder.Entity<TicketDetailsTbl>(entity =>
        {
            entity.HasKey(e => e.TicketDetailId);

            entity.ToTable("TicketDetailsTbl");

            entity.Property(e => e.TicketDetailId)
                .ValueGeneratedNever()
                .HasColumnName("TicketDetailID");
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

            entity.ToTable("TicketStatusTbl");

            entity.Property(e => e.TicketStatusId).HasColumnName("TicketStatusID");
            entity.Property(e => e.TicketStatusTitle).HasMaxLength(100);
        });

        modelBuilder.Entity<TicketTbl>(entity =>
        {
            entity.HasKey(e => e.TicketId);

            entity.ToTable("TicketTbl");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.RegisterDate).HasMaxLength(10);
            entity.Property(e => e.RegisterTime).HasMaxLength(8);
            entity.Property(e => e.TicketStatusId).HasColumnName("TicketStatusID");

            entity.HasOne(d => d.Admin).WithMany(p => p.TicketTbls)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TicketTbl_TicketTbl");

            entity.HasOne(d => d.TicketStatus).WithMany(p => p.TicketTbls)
                .HasForeignKey(d => d.TicketStatusId)
                .HasConstraintName("FK_TicketTbl_TicketStatusTbl");
        });

        modelBuilder.Entity<TicketTypeTbl>(entity =>
        {
            entity.HasKey(e => e.TicketTypeId).HasName("PK_TicketType");

            entity.ToTable("TicketTypeTbl");

            entity.Property(e => e.TicketTypeId).HasColumnName("TicketTypeID");
            entity.Property(e => e.TicketType).HasMaxLength(100);
        });

        modelBuilder.Entity<TollAmountTypeTbl>(entity =>
        {
            entity.HasKey(e => e.TollAmountId);

            entity.ToTable("TollAmountTypeTbl");

            entity.Property(e => e.TollAmountId).HasColumnName("TollAmountID");
            entity.Property(e => e.TollAmountType).HasMaxLength(100);
        });

        modelBuilder.Entity<TravelGoalsTypeTbl>(entity =>
        {
            entity.HasKey(e => e.TravelGoalsId).HasName("PK_TravelGoalsType");

            entity.ToTable("TravelGoalsTypeTbl");

            entity.Property(e => e.TravelGoalsId).HasColumnName("TravelGoalsID");
            entity.Property(e => e.TravelGoalsType).HasMaxLength(100);
        });

        modelBuilder.Entity<TypeOfEmploymentTbl>(entity =>
        {
            entity.HasKey(e => e.TypeOfEmploymentId);

            entity.ToTable("TypeOfEmploymentTbl");

            entity.Property(e => e.TypeOfEmploymentId).HasColumnName("TypeOfEmploymentID");
            entity.Property(e => e.TypeOfEmploymentTitle).HasMaxLength(300);
        });

        modelBuilder.Entity<TypeOfMissionTbl>(entity =>
        {
            entity.HasKey(e => e.TypeOfMissionId).HasName("PK_TypeOfMission");

            entity.ToTable("TypeOfMissionTbl");

            entity.Property(e => e.TypeOfMissionId).HasColumnName("TypeOfMissionID");
            entity.Property(e => e.TypeOfMissionTitle).HasMaxLength(300);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
