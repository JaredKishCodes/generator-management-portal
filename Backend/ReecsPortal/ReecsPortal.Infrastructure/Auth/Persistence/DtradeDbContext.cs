using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReecsPortal.Domain.DTradeModels;
using ReecsPortal.Infrastructure.DTradeModels;

namespace ReecsPortal.Infrastructure.Auth.Persistence;

public partial class DtradeDbContext : DbContext
{
    public DtradeDbContext()
    {
    }

    public DtradeDbContext(DbContextOptions<DtradeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Dipcer> Dipcers { get; set; }

    public virtual DbSet<DipcerRe> DipcerRes { get; set; }

    public virtual DbSet<HvdcRt> HvdcRts { get; set; }

    public virtual DbSet<TblCustRenom> TblCustRenoms { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblEffRate> TblEffRates { get; set; }

    public virtual DbSet<TblGenMatrix> TblGenMatrices { get; set; }

    public virtual DbSet<TblGenRenom> TblGenRenoms { get; set; }

    public virtual DbSet<TblGenerator> TblGenerators { get; set; } //oninit

    public virtual DbSet<TblIemoppriceDatum> TblIemoppriceData { get; set; }

    public virtual DbSet<TblLoadDispatch> TblLoadDispatches { get; set; }

    public virtual DbSet<TblLoadMatrix> TblLoadMatrices { get; set; }

    public virtual DbSet<TblLoadProfile> TblLoadProfiles { get; set; }

    public virtual DbSet<TblMarketGlance> TblMarketGlances { get; set; }

    public virtual DbSet<TblMarketPriceForecast> TblMarketPriceForecasts { get; set; }

    public virtual DbSet<TblNom> TblNoms { get; set; }

    public virtual DbSet<TblPlant> TblPlants { get; set; }

    public virtual DbSet<TblPlantLoading> TblPlantLoadings { get; set; }

    public virtual DbSet<TblPlantsCapacity> TblPlantsCapacities { get; set; }

    public virtual DbSet<TblRtd> TblRtds { get; set; }

    public virtual DbSet<TblRtdbill> TblRtdbills { get; set; }

    
    public virtual DbSet<TblUser> TblUsers { get; set; } //User Db

    public virtual DbSet<TblUserLog> TblUserLogs { get; set; }

    public virtual DbSet<VwDipcer> VwDipcers { get; set; }

    public virtual DbSet<VwEffrate> VwEffrates { get; set; }

    public virtual DbSet<VwGenMatrix> VwGenMatrices { get; set; }

    public virtual DbSet<VwGenRenom> VwGenRenoms { get; set; }

    public virtual DbSet<VwHvdc> VwHvdcs { get; set; }

    public virtual DbSet<VwHvdcprice> VwHvdcprices { get; set; }

    public virtual DbSet<VwLoadBilling> VwLoadBillings { get; set; }

    public virtual DbSet<VwLoadDispatch> VwLoadDispatches { get; set; }

    public virtual DbSet<VwLoadMatrix> VwLoadMatrices { get; set; }

    public virtual DbSet<VwLoadProfile> VwLoadProfiles { get; set; }

    public virtual DbSet<VwLoadRenom> VwLoadRenoms { get; set; }

    public virtual DbSet<VwMarketForecast> VwMarketForecasts { get; set; }

    public virtual DbSet<VwMosysPrice> VwMosysPrices { get; set; }

    public virtual DbSet<VwNom> VwNoms { get; set; }

    public virtual DbSet<VwPlantCapacity> VwPlantCapacities { get; set; }

    public virtual DbSet<VwPlantloading> VwPlantloadings { get; set; }

    public virtual DbSet<VwRtd> VwRtds { get; set; }

    public virtual DbSet<VwRtdbill> VwRtdbills { get; set; }

    public virtual DbSet<VwTotalSettlePrice> VwTotalSettlePrices { get; set; }

    public virtual DbSet<VwTrtd> VwTrtds { get; set; }

    public virtual DbSet<VwUser> VwUsers { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.ContactName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Dipcer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DIPCER");

            entity.Property(e => e.Lmp).HasColumnName("LMP");
            entity.Property(e => e.LmpCongestion).HasColumnName("LMP_CONGESTION");
            entity.Property(e => e.LmpLoss).HasColumnName("LMP_LOSS");
            entity.Property(e => e.LmpSmp).HasColumnName("LMP_SMP");
            entity.Property(e => e.PricingFlag)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("PRICING_FLAG");
            entity.Property(e => e.RegionName)
                .HasMaxLength(10)
                .HasColumnName("REGION_NAME");
            entity.Property(e => e.ResourceName)
                .HasMaxLength(20)
                .HasColumnName("RESOURCE_NAME");
            entity.Property(e => e.SchedMw).HasColumnName("SCHED_MW");
            entity.Property(e => e.TimeInterval)
                .HasColumnType("datetime")
                .HasColumnName("TIME_INTERVAL");
        });

        modelBuilder.Entity<DipcerRe>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DIPCER_RES");

            entity.Property(e => e.MarketGlanceReg)
                .HasMaxLength(50)
                .HasColumnName("MARKET_GLANCE_REG");
            entity.Property(e => e.ResourceName)
                .HasMaxLength(50)
                .HasColumnName("RESOURCE_NAME");
        });

        modelBuilder.Entity<HvdcRt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HVDC_RT");

            entity.Property(e => e.DelDate).HasColumnType("datetime");
            entity.Property(e => e.Rid)
                .ValueGeneratedOnAdd()
                .HasColumnName("rid");
            entity.Property(e => e.TlName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TL_NAME");
        });

        modelBuilder.Entity<TblCustRenom>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblCustRenom");

            entity.Property(e => e.ApprovedBy).HasMaxLength(50);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.Nvalue).HasColumnName("NValue");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.Rid)
                .ValueGeneratedOnAdd()
                .HasColumnName("rid");
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustCode);

            entity.ToTable("tblCustomer");

            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.Archived)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustAddress)
                .HasMaxLength(50)
                .HasColumnName("cust_address");
            entity.Property(e => e.CustFullName)
                .HasMaxLength(50)
                .HasColumnName("Cust_Full_Name");
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .HasColumnName("cust_name");
            entity.Property(e => e.DemandMw).HasColumnName("DemandMW");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblEffRate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblEffRate");

            entity.Property(e => e.PriceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("price_id");
        });

        modelBuilder.Entity<TblGenMatrix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblGenMatrix");

            entity.Property(e => e.Approved)
                .HasDefaultValue(0)
                .HasColumnName("approved");
            entity.Property(e => e.Archived)
                .HasDefaultValue(0)
                .HasColumnName("archived");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GenCode).HasColumnName("gen_code");
            entity.Property(e => e.Rid)
                .ValueGeneratedOnAdd()
                .HasColumnName("rid");
            entity.Property(e => e.Usercode).HasColumnName("usercode");
        });

        modelBuilder.Entity<TblGenRenom>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblGenRenom");

            entity.Property(e => e.ApprovedBy).HasMaxLength(50);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nvalue).HasColumnName("NValue");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.Rid)
                .ValueGeneratedOnAdd()
                .HasColumnName("rid");
        });

        modelBuilder.Entity<TblGenerator>(entity =>
        {
            entity.HasKey(e => e.GenCode);

            entity.ToTable("tblGenerator");

            entity.Property(e => e.GenCode).HasColumnName("gen_code");
            entity.Property(e => e.Archived)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.CapacityMw).HasColumnName("CapacityMW");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GenAddress)
                .HasMaxLength(50)
                .HasColumnName("gen_address");
            entity.Property(e => e.GenFullName)
                .HasMaxLength(50)
                .HasColumnName("gen_Full_Name");
            entity.Property(e => e.GenName)
                .HasMaxLength(50)
                .HasColumnName("gen_name");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblIemoppriceDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblIEMOPPriceData");

            entity.Property(e => e.DelInterval).HasColumnType("datetime");
            entity.Property(e => e.Demand).HasColumnName("demand");
            entity.Property(e => e.ParamName)
                .HasMaxLength(50)
                .HasColumnName("param_name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Rid)
                .ValueGeneratedOnAdd()
                .HasColumnName("rid");
            entity.Property(e => e.Supply).HasColumnName("supply");
        });

        modelBuilder.Entity<TblLoadDispatch>(entity =>
        {
            entity.HasKey(e => e.ProfileCode);

            entity.ToTable("tblLoadDispatch");

            entity.Property(e => e.ProfileCode).HasColumnName("profile_code");
            entity.Property(e => e.Archived).HasDefaultValue(0);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.DelType).HasDefaultValue(0);
            entity.Property(e => e.Fo)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("FO");
            entity.Property(e => e.IsForecast).HasDefaultValue(0);
            entity.Property(e => e.Mo)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("MO");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Pcode).HasColumnName("pcode");
            entity.Property(e => e.Wd)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WD");
        });

        modelBuilder.Entity<TblLoadMatrix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblLoadMatrix");

            entity.Property(e => e.Approved)
                .HasDefaultValue(0)
                .HasColumnName("approved");
            entity.Property(e => e.Archived)
                .HasDefaultValue(0)
                .HasColumnName("archived");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.Rid)
                .ValueGeneratedOnAdd()
                .HasColumnName("rid");
            entity.Property(e => e.Usercode).HasColumnName("usercode");
        });

        modelBuilder.Entity<TblLoadProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileCode);

            entity.ToTable("tblLoadProfile");

            entity.Property(e => e.ProfileCode).HasColumnName("profile_code");
            entity.Property(e => e.Archived).HasDefaultValue(0);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.DelType).HasDefaultValue(0);
            entity.Property(e => e.Fo)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("FO");
            entity.Property(e => e.IsForecast).HasDefaultValue(0);
            entity.Property(e => e.Mo)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("MO");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Pcode).HasColumnName("pcode");
            entity.Property(e => e.Wd)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("WD");
        });

        modelBuilder.Entity<TblMarketGlance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblMARKET_GLANCE");

            entity.Property(e => e.Demand).HasColumnName("DEMAND");
            entity.Property(e => e.DisplayTimeInterval)
                .HasColumnType("datetime")
                .HasColumnName("displayTimeInterval");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MktType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MKT_TYPE");
            entity.Property(e => e.Price).HasColumnName("PRICE");
            entity.Property(e => e.RegionName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("REGION_NAME");
            entity.Property(e => e.RunTime)
                .HasColumnType("datetime")
                .HasColumnName("RUN_TIME");
            entity.Property(e => e.Suppy).HasColumnName("SUPPY");
            entity.Property(e => e.TimeInterval)
                .HasColumnType("datetime")
                .HasColumnName("TIME_INTERVAL");
        });

        modelBuilder.Entity<TblMarketPriceForecast>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblMARKET_PRICE_FORECAST");

            entity.Property(e => e.Lmp).HasColumnName("LMP");
            entity.Property(e => e.ResourceName)
                .HasMaxLength(20)
                .HasColumnName("RESOURCE_NAME");
            entity.Property(e => e.TimeInterval)
                .HasColumnType("datetime")
                .HasColumnName("TIME_INTERVAL");
        });

        modelBuilder.Entity<TblNom>(entity =>
        {
            entity.HasKey(e => e.NomCode);

            entity.ToTable("tblNom");

            entity.Property(e => e.NomCode).HasColumnName("nom_code");
            entity.Property(e => e.Archived).HasDefaultValue(0);
            entity.Property(e => e.Confirmed).HasMaxLength(1);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.DelType).HasDefaultValue(0);
            entity.Property(e => e.IntervalId).HasColumnName("IntervalID");
            entity.Property(e => e.IsSubmitted)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isSubmitted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Renom).HasColumnName("renom");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TblPlant>(entity =>
        {
            entity.HasKey(e => e.PlantCode);

            entity.ToTable("tblPlants");

            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Archived)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.Company).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PlantName)
                .HasMaxLength(50)
                .HasColumnName("plant_name");
            entity.Property(e => e.PlantPickerCode)
                .HasMaxLength(3)
                .HasColumnName("plant_picker_code");
            entity.Property(e => e.Psag)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PSAG");
        });

        modelBuilder.Entity<TblPlantLoading>(entity =>
        {
            entity.HasKey(e => e.PlantLoadingCode);

            entity.ToTable("tblPlantLoading");

            entity.Property(e => e.PlantLoadingCode).HasColumnName("plant_loading_code");
            entity.Property(e => e.Archived)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Load).HasColumnName("load");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Petsa).HasColumnName("petsa");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<TblPlantsCapacity>(entity =>
        {
            entity.HasKey(e => e.PlantCapCode);

            entity.ToTable("tblPlantsCapacity");

            entity.Property(e => e.PlantCapCode).HasColumnName("plant_cap_code");
            entity.Property(e => e.Archived)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Petsa).HasColumnName("petsa");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<TblRtd>(entity =>
        {
            entity.HasKey(e => e.NomCode);

            entity.ToTable("tblRTD");

            entity.Property(e => e.NomCode).HasColumnName("nom_code");
            entity.Property(e => e.Archived).HasDefaultValue(0);
            entity.Property(e => e.Confirmed).HasMaxLength(1);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.DelType).HasDefaultValue(0);
            entity.Property(e => e.IntervalId).HasColumnName("IntervalID");
            entity.Property(e => e.IsSubmitted)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isSubmitted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Renom).HasColumnName("renom");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TblRtdbill>(entity =>
        {
            entity.HasKey(e => e.NomCode);

            entity.ToTable("tblRTDBill");

            entity.Property(e => e.NomCode).HasColumnName("nom_code");
            entity.Property(e => e.Archived).HasDefaultValue(0);
            entity.Property(e => e.Confirmed).HasMaxLength(1);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.DelType).HasDefaultValue(0);
            entity.Property(e => e.IntervalId).HasColumnName("IntervalID");
            entity.Property(e => e.IsSubmitted)
                .HasMaxLength(1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isSubmitted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Renom).HasColumnName("renom");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Usercode);

            entity.ToTable("tblUsers");

            entity.Property(e => e.Usercode).HasColumnName("usercode");
            entity.Property(e => e.AccessType)
                .HasMaxLength(5)
                .HasDefaultValueSql("(user_name())")
                .HasColumnName("accessType");
            entity.Property(e => e.ContactAddress).HasMaxLength(50);
            entity.Property(e => e.ContactEmail).HasMaxLength(50);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.ContactNum).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Pgroup).HasColumnName("PGroup");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Verified)
                .HasMaxLength(1)
                .HasColumnName("verified");
        });

        modelBuilder.Entity<TblUserLog>(entity =>
        {
            entity.HasKey(e => e.RedId).HasName("PK_redID");

            entity.ToTable("tblUserLogs");

            entity.Property(e => e.RedId).HasColumnName("redID");
            entity.Property(e => e.Activity)
                .HasMaxLength(50)
                .HasColumnName("activity");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<VwDipcer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DIPCER");

            entity.Property(e => e.LmpSmp).HasColumnName("LMP_SMP");
            entity.Property(e => e.RegionName)
                .HasMaxLength(10)
                .HasColumnName("REGION_NAME");
            entity.Property(e => e.TimeInterval)
                .HasColumnType("datetime")
                .HasColumnName("TIME_INTERVAL");
        });

        modelBuilder.Entity<VwEffrate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_EFFRATE");

            entity.Property(e => e.Sp).HasColumnName("SP");
        });

        modelBuilder.Entity<VwGenMatrix>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_GenMatrix");

            entity.Property(e => e.Approved).HasColumnName("approved");
            entity.Property(e => e.Archived).HasMaxLength(1);
            entity.Property(e => e.CapacityMw).HasColumnName("CapacityMW");
            entity.Property(e => e.ContactAddress).HasMaxLength(50);
            entity.Property(e => e.ContactEmail).HasMaxLength(50);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.ContactNum).HasMaxLength(50);
            entity.Property(e => e.GenAddress)
                .HasMaxLength(50)
                .HasColumnName("gen_address");
            entity.Property(e => e.GenCode).HasColumnName("gen_code");
            entity.Property(e => e.GenFullName)
                .HasMaxLength(50)
                .HasColumnName("gen_Full_Name");
            entity.Property(e => e.GenName)
                .HasMaxLength(50)
                .HasColumnName("gen_name");
            entity.Property(e => e.MatrixArchived).HasColumnName("matrixArchived");
            entity.Property(e => e.Usercode).HasColumnName("usercode");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<VwGenRenom>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_GenRenom");

            entity.Property(e => e.ApprovedBy).HasMaxLength(50);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.GenName)
                .HasMaxLength(50)
                .HasColumnName("gen_name");
            entity.Property(e => e.Nvalue).HasColumnName("NValue");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.Rid).HasColumnName("rid");
        });

        modelBuilder.Entity<VwHvdc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_HVDC");

            entity.Property(e => e.DelDate).HasMaxLength(4000);
            entity.Property(e => e.Mw).HasColumnName("MW");
            entity.Property(e => e.TlName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TL_NAME");
        });

        modelBuilder.Entity<VwHvdcprice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_HVDCPrice");

            entity.Property(e => e.MosysPrice).HasColumnName("MOSysPrice");
            entity.Property(e => e.Mw).HasColumnName("MW");
            entity.Property(e => e.TimeInterval)
                .HasColumnType("datetime")
                .HasColumnName("TIME_INTERVAL");
            entity.Property(e => e.TlName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TL_NAME");
        });

        modelBuilder.Entity<VwLoadBilling>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_LoadBilling");

            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .HasColumnName("cust_name");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
        });

        modelBuilder.Entity<VwLoadDispatch>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_LoadDispatch");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .HasColumnName("cust_name");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.Fo)
                .HasMaxLength(1)
                .HasColumnName("FO");
            entity.Property(e => e.Mo)
                .HasMaxLength(1)
                .HasColumnName("MO");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Pcode).HasColumnName("pcode");
            entity.Property(e => e.ProfileCode).HasColumnName("profile_code");
            entity.Property(e => e.Usercode).HasColumnName("usercode");
            entity.Property(e => e.Wd)
                .HasMaxLength(1)
                .HasColumnName("WD");
        });

        modelBuilder.Entity<VwLoadMatrix>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_LoadMatrix");

            entity.Property(e => e.Approved).HasColumnName("approved");
            entity.Property(e => e.Archived).HasMaxLength(1);
            entity.Property(e => e.ContactAddress).HasMaxLength(50);
            entity.Property(e => e.ContactEmail).HasMaxLength(50);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.ContactNum).HasMaxLength(50);
            entity.Property(e => e.CustAddress)
                .HasMaxLength(50)
                .HasColumnName("cust_address");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.CustFullName)
                .HasMaxLength(50)
                .HasColumnName("Cust_Full_Name");
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .HasColumnName("cust_name");
            entity.Property(e => e.DemandMw).HasColumnName("DemandMW");
            entity.Property(e => e.MatrixArchived).HasColumnName("matrixArchived");
            entity.Property(e => e.Usercode).HasColumnName("usercode");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<VwLoadProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_loadProfile");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .HasColumnName("cust_name");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.Fo)
                .HasMaxLength(1)
                .HasColumnName("FO");
            entity.Property(e => e.Mo)
                .HasMaxLength(1)
                .HasColumnName("MO");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Pcode).HasColumnName("pcode");
            entity.Property(e => e.ProfileCode).HasColumnName("profile_code");
            entity.Property(e => e.Usercode).HasColumnName("usercode");
            entity.Property(e => e.Wd)
                .HasMaxLength(1)
                .HasColumnName("WD");
        });

        modelBuilder.Entity<VwLoadRenom>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_LoadRenom");

            entity.Property(e => e.ApprovedBy).HasMaxLength(50);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .HasColumnName("cust_name");
            entity.Property(e => e.Nvalue).HasColumnName("NValue");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.Rid).HasColumnName("rid");
        });

        modelBuilder.Entity<VwMarketForecast>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MARKET_FORECAST");

            entity.Property(e => e.Lmp).HasColumnName("LMP");
            entity.Property(e => e.MarketGlanceReg)
                .HasMaxLength(50)
                .HasColumnName("MARKET_GLANCE_REG");
            entity.Property(e => e.ResourceName)
                .HasMaxLength(20)
                .HasColumnName("RESOURCE_NAME");
            entity.Property(e => e.TimeInterval)
                .HasColumnType("datetime")
                .HasColumnName("TIME_INTERVAL");
        });

        modelBuilder.Entity<VwMosysPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MOSysPrice");

            entity.Property(e => e.MosysPrice).HasColumnName("MOSysPrice");
            entity.Property(e => e.TimeInterval)
                .HasColumnType("datetime")
                .HasColumnName("TIME_INTERVAL");
        });

        modelBuilder.Entity<VwNom>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_nom");

            entity.Property(e => e.Confirmed).HasMaxLength(1);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.GenName)
                .HasMaxLength(50)
                .HasColumnName("gen_name");
            entity.Property(e => e.IsSubmitted)
                .HasMaxLength(1)
                .HasColumnName("isSubmitted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NomCode).HasColumnName("nom_code");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Usercode).HasColumnName("usercode");
        });

        modelBuilder.Entity<VwPlantCapacity>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_plantCapacity");

            entity.Property(e => e.Archived).HasMaxLength(1);
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.GenCode).HasColumnName("gen_code");
            entity.Property(e => e.GenName)
                .HasMaxLength(50)
                .HasColumnName("gen_name");
            entity.Property(e => e.Petsa).HasColumnName("petsa");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Usercode).HasColumnName("usercode");
        });

        modelBuilder.Entity<VwPlantloading>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_plantloading");

            entity.Property(e => e.Archived).HasMaxLength(1);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.Load).HasColumnName("load");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Petsa).HasColumnName("petsa");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.PlantLoadingCode).HasColumnName("plant_loading_code");
            entity.Property(e => e.PlantName)
                .HasMaxLength(50)
                .HasColumnName("plant_name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<VwRtd>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RTD");

            entity.Property(e => e.Confirmed).HasMaxLength(1);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.GenName)
                .HasMaxLength(50)
                .HasColumnName("gen_name");
            entity.Property(e => e.IntervalId).HasColumnName("IntervalID");
            entity.Property(e => e.IsSubmitted)
                .HasMaxLength(1)
                .HasColumnName("isSubmitted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NomCode).HasColumnName("nom_code");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Renom).HasColumnName("renom");
            entity.Property(e => e.Status).HasMaxLength(1);
        });

        modelBuilder.Entity<VwRtdbill>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RTDBill");

            entity.Property(e => e.Confirmed).HasMaxLength(1);
            entity.Property(e => e.CreateBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.DelMw).HasColumnName("DelMW");
            entity.Property(e => e.GenName)
                .HasMaxLength(50)
                .HasColumnName("gen_name");
            entity.Property(e => e.IntervalId).HasColumnName("IntervalID");
            entity.Property(e => e.IsSubmitted)
                .HasMaxLength(1)
                .HasColumnName("isSubmitted");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NomCode).HasColumnName("nom_code");
            entity.Property(e => e.PlantCode).HasColumnName("plant_code");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Renom).HasColumnName("renom");
            entity.Property(e => e.Status).HasMaxLength(1);
        });

        modelBuilder.Entity<VwTotalSettlePrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_TotalSettlePrice");

            entity.Property(e => e.TsettlePrice).HasColumnName("TSettlePrice");
        });

        modelBuilder.Entity<VwTrtd>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_TRTD");

            entity.Property(e => e.Trtd).HasColumnName("TRTD");
        });

        modelBuilder.Entity<VwUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_users");

            entity.Property(e => e.AccessLevel)
                .HasMaxLength(5)
                .HasColumnName("access_level");
            entity.Property(e => e.CustAddress)
                .HasMaxLength(50)
                .HasColumnName("cust_address");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");
            entity.Property(e => e.CustFullName)
                .HasMaxLength(50)
                .HasColumnName("Cust_Full_Name");
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .HasColumnName("cust_name");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Pgroup).HasColumnName("PGroup");
            entity.Property(e => e.Usercode).HasColumnName("usercode");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Verified)
                .HasMaxLength(1)
                .HasColumnName("verified");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
