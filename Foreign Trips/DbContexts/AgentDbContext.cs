﻿using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.DbContexts
{
    public class AgentDbContext : DbContext
    {
        public AgentDbContext
            (DbContextOptions<AgentDbContext> options)
            : base(options)
        {

        }
        public DbSet<InternationalAdminTbl> InternationalAdminTbl { get; set; } = null!;
        public DbSet<AgentTbl> AgentTbl { get; set; } = null!;
        public DbSet<LoginTbl> LoginTbl { get; set; } = null!;
        public DbSet<RequestStatusTbl> RequestStatusTbl { get; set; } = null!;
        public DbSet<RequestTbl> RequestTbl { get; set; } = null!;
        public DbSet<ProvinceTbl> ProvinceTbl { get; set; } = null!;
        public DbSet<AgentStatusTbl> AgentStatusTbl { get; set; } = null!;
        public DbSet<TypeOfMissionTbl> TypeOfMissionTbl { get; set; } = null!;
        public DbSet<TypeOfEmploymentTbl> TypeOfEmploymentTbl { get; set; } = null!;
        public DbSet<PositionTypeTbl> PositionTypeTbl { get; set; } = null!;
        public DbSet<CityTbl> CityTbl { get; set; } = null!;
        public DbSet<TicketTbl> TicketTbl { get; set; } = null!;
        public DbSet<TicketDetailsTbl> TicketDetailsTbl { get; set; } = null!;
        public DbSet<Report> Report { get; set; } = null;
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<RuleTbl> RuleTbl { get; set; } = null!;
        public DbSet<MainAdminTbl> MainAdminTbl { get; set; } = null!;
        public DbSet<ForeignDelegrationTbl> ForeginDelegrationTbl { get; set; } = null!;
        public DbSet<SupervisorTbl> SupervisorTbl { get; set; } = null;
        public DbSet<InternationalExpertTbl> InternationalExpertTbl { get; set; } = null;
        public DbSet<MaritalStatusTbl> MaritalStatusTbl { get; set; } = null!;
        public DbSet<LanguageType> LanguageType { get; set; } = null!;
        public DbSet<TravelGoalsTypeTbl> TravelGoalsTypeTbl { get; set; } = null!;
        public DbSet<JobGoalsTypeTbl> JobGoalsTypeTbl { get; set; } = null!;
        public DbSet<DeviceNameItypeTbl> DeviceNameItypeTbl { get; set; } = null!;
        public DbSet<PassportTbl> PassportTbl { get; set; } = null!;
        public DbSet<RightOfMissionTbl> RightOfMissionTbl { get; set; } = null!;
        public DbSet<RightOfCommutingTypeTbl> RightOfCommutingTypeTbl { get; set; } = null!;
        public DbSet<RightToEducationTbl> RightToEducationTbl { get; set; } = null!;
        public DbSet<MessageTbl> MessageTbl { get; set; } = null!;
    }
}
