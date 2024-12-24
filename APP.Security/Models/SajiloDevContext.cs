using APP.Security.Models.Cafe;
using APP.Security.Models.Menu;
using APP.Security.Models.Users;
using Microsoft.EntityFrameworkCore;
using APP.Cafe;
namespace APP.Security.Models;

public partial class CafeContext : DbContext
{
    public CafeContext()
    {
    }

    public CafeContext(DbContextOptions<CafeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CafeM> Cafe { get; set; }

    public virtual DbSet<Cafestaff> Cafestaffs { get; set; }

    public virtual DbSet<ClkStatus> ClkStatuses { get; set; }

    public virtual DbSet<Credittransaction> Credittransactions { get; set; }

    public virtual DbSet<SecApplication> SecApplications { get; set; }

    public virtual DbSet<SecFunction> SecFunctions { get; set; }

    public virtual DbSet<SecMenu> SecMenus { get; set; }

    public virtual DbSet<SecModule> SecModules { get; set; }

    public virtual DbSet<SecModuleFunction> SecModuleFunctions { get; set; }

    public virtual DbSet<SecRole> SecRoles { get; set; }

    public virtual DbSet<SecStaffRole> SecStaffRoles { get; set; }

    public virtual DbSet<SecUser> SecUsers { get; set; }

    public virtual DbSet<SecUsersStatus> SecUsersStatuses { get; set; }


    public virtual DbSet<Subscription> Subscriptions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _=modelBuilder.Entity<CafeM>(entity =>
        {
            _=entity.HasKey(e => e.Id).HasName("cafe_pkey");

            _=entity.ToTable("cafe", "security");

            _=entity.Property(e => e.Id).HasColumnName("Id");
            _=entity.Property(e => e.Address).HasColumnName("address");
            _=entity.Property(e => e.CafeLogo).HasColumnName("cafe_logo");
            _=entity.Property(e => e.Cafename)
                .HasMaxLength(150)
                .HasColumnName("cafename");
            _=entity.Property(e => e.EntryDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("EntryDate");
            _=entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

            _=entity.HasOne(d => d.Subscription).WithMany(p => p.Caves)
                .HasForeignKey(d => d.Subscriptionid)
                .HasConstraintName("cafe_subscriptionid_fkey");
        });

        modelBuilder.Entity<Cafestaff>(entity =>
        {
            _=entity.HasKey(e => e.Staffid).HasName("cafestaff_pkey");

            _=entity.ToTable("cafestaff", "security");

            _=entity.Property(e => e.Staffid).HasColumnName("staffid");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.EntryDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("EntryDate");
            _=entity.Property(e => e.Enddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            _=entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            _=entity.Property(e => e.Startdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            _=entity.Property(e => e.Name)
               .HasColumnName("name");
            _=entity.Property(e => e.password)
               .HasColumnName("password");
            _=entity.Property(e => e.email)
                .HasColumnName("email");
            _=entity.Property(e => e.phoneNo)
                .HasColumnName("phoneno");

            entity.HasOne(d => d.Cafe).WithMany(p => p.Cafestaffs)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("cafestaff_Id_fkey");

        });

        _=modelBuilder.Entity<ClkStatus>(entity =>
        {
            _=entity.HasKey(e => e.StatusId).HasName("clk_status_pk");

            _=entity.ToTable("clk_status", "security");

            _=entity.HasIndex(e => e.StatusDesc, "clk_status_un").IsUnique();

            _=entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            _=entity.Property(e => e.IsActive)
                .HasDefaultValue(0)
                .HasColumnName("is_active");
            _=entity.Property(e => e.IsVerif)
                .HasDefaultValue(false)
                .HasColumnName("is_verif");
            _=entity.Property(e => e.StatusDesc)
                .HasColumnType("character varying")
                .HasColumnName("status_desc");
            _=entity.Property(e => e.VerifDesc)
                .HasMaxLength(100)
                .HasColumnName("verif_desc");
        });

        modelBuilder.Entity<Credittransaction>(entity =>
        {
            _=entity.HasKey(e => e.Transactionid).HasName("credittransactions_pkey");

            _=entity.ToTable("credittransactions", "account");

            _=entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            _=entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Id).HasColumnName("Id");
            _=entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            _=entity.Property(e => e.Orderid).HasColumnName("orderid");
            _=entity.Property(e => e.Transactiondate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transactiondate");
            _=entity.Property(e => e.Transactiontype)
                .HasMaxLength(50)
                .HasColumnName("transactiontype");
            _=entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        _=modelBuilder.Entity<SecApplication>(entity =>
        {
            _=entity.HasKey(e => e.ApplicationId).HasName("sec_applications_pkey");

            _=entity.ToTable("sec_applications", "security");

            _=entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            _=entity.Property(e => e.ApplicationDescription)
                .HasMaxLength(100)
                .HasColumnName("application_description");
            _=entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            _=entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");
            _=entity.Property(e => e.OrderCode).HasColumnName("order_code");
        });

        _=modelBuilder.Entity<SecFunction>(entity =>
        {
            _=entity.HasKey(e => e.FunCd).HasName("sec_functions_pkey");

            _=entity.ToTable("sec_functions", "security");

            _=entity.HasIndex(e => e.StatusId, "uk_functions_status_id").IsUnique();

            _=entity.Property(e => e.FunCd)
                .HasMaxLength(2)
                .HasColumnName("fun_cd");
            _=entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            _=entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");
            _=entity.Property(e => e.FunDesc)
                .HasMaxLength(10)
                .HasColumnName("fun_desc");
            _=entity.Property(e => e.StatusId).HasColumnName("status_id");

            _=entity.HasOne(d => d.Status).WithOne(p => p.SecFunction)
                .HasForeignKey<SecFunction>(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_functions_status_id");
        });

        _=modelBuilder.Entity<SecMenu>(entity =>
        {
            _=entity.HasKey(e => e.MenuId).HasName("sec_menu_pkey");

            _=entity.ToTable("sec_menu", "security");

            _=entity.Property(e => e.MenuId)
                .ValueGeneratedNever()
                .HasColumnName("menu_id");
            _=entity.Property(e => e.HasChild)
                .HasMaxLength(1)
                .HasColumnName("has_child");
            _=entity.Property(e => e.MUrl)
                .HasMaxLength(200)
                .HasColumnName("m_url");
            _=entity.Property(e => e.MenuIcon)
                .HasMaxLength(100)
                .HasColumnName("menu_icon");
            _=entity.Property(e => e.MenuText)
                .HasMaxLength(50)
                .HasColumnName("menu_text");
            _=entity.Property(e => e.OrderNo).HasColumnName("order_no");
            _=entity.Property(e => e.ParentId).HasColumnName("parent_id");
            _=entity.Property(e => e.SecApl)
                .HasMaxLength(1)
                .HasColumnName("sec_apl");
            _=entity.Property(e => e.ToolTip)
                .HasMaxLength(100)
                .HasColumnName("tool_tip");
            _=entity.Property(e => e.UsedIn)
                .HasMaxLength(4)
                .HasColumnName("used_in");
        });

        _=modelBuilder.Entity<SecModule>(entity =>
        {
            _=entity.HasKey(e => new { e.ApplicationId, e.ModuleId }).HasName("sec_modules_pkey");

            _=entity.ToTable("sec_modules", "security");

            _=entity.HasIndex(e => e.ApplicationId, "module_app_fk_i");

            _=entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            _=entity.Property(e => e.ModuleId)
                .HasMaxLength(50)
                .HasColumnName("module_id");
            _=entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            _=entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");
            _=entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            _=entity.Property(e => e.MOrderCode).HasColumnName("m_order_code");
            _=entity.Property(e => e.McRestricted)
                .HasMaxLength(1)
                .HasColumnName("mc_restricted");
            _=entity.Property(e => e.MenuId).HasColumnName("menu_id");
            _=entity.Property(e => e.MenuName)
                .HasMaxLength(100)
                .HasColumnName("menu_name");
            _=entity.Property(e => e.ModuleDescription)
                .HasMaxLength(120)
                .HasColumnName("module_description");
            _=entity.Property(e => e.ModuleType)
                .HasMaxLength(1)
                .HasColumnName("module_type");
            _=entity.Property(e => e.UsesBy)
                .HasMaxLength(4)
                .HasColumnName("uses_by");

            _=entity.HasOne(d => d.Application).WithMany(p => p.SecModules)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_modules_application_id_fkey");

            _=entity.HasOne(d => d.Menu).WithMany(p => p.SecModules)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("sec_modules_menu_id_fkey");
        });

        _=modelBuilder.Entity<SecModuleFunction>(entity =>
        {
            _=entity.HasKey(e => new { e.ApplicationId, e.ModuleId, e.FunCd }).HasName("sec_module_functions_pkey");

            _=entity.ToTable("sec_module_functions", "security");

            _=entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            _=entity.Property(e => e.ModuleId)
                .HasMaxLength(50)
                .HasColumnName("module_id");
            _=entity.Property(e => e.FunCd)
                .HasMaxLength(2)
                .HasColumnName("fun_cd");
            _=entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            _=entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");

            _=entity.HasOne(d => d.Application).WithMany(p => p.SecModuleFunctions)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_module_functions_application_id_fkey1");

            _=entity.HasOne(d => d.FunCdNavigation).WithMany(p => p.SecModuleFunctions)
                .HasForeignKey(d => d.FunCd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_module_functions_fun_cd_fkey");

            _=entity.HasOne(d => d.SecModule).WithMany(p => p.SecModuleFunctions)
                .HasForeignKey(d => new { d.ApplicationId, d.ModuleId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_module_functions_fk");
        });

        _=modelBuilder.Entity<SecRole>(entity =>
        {
            _=entity.HasKey(e => new { e.ApplicationId, e.RoleId }).HasName("sec_roles_pkey");

            _=entity.ToTable("sec_roles", "security");

            _=entity.HasIndex(e => e.ApplicationId, "role_app_fk_i");

            _=entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            _=entity.Property(e => e.RoleId)
                .HasMaxLength(30)
                .HasColumnName("role_id");
            _=entity.Property(e => e.DbRole)
                .HasMaxLength(30)
                .HasColumnName("db_role");
            _=entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            _=entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");
            _=entity.Property(e => e.RoleDescription)
                .HasMaxLength(120)
                .HasColumnName("role_description");

            _=entity.HasOne(d => d.Application).WithMany(p => p.SecRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_roles_application_id_fkey");
        });

        _=modelBuilder.Entity<SecStaffRole>(entity =>
        {
            _=entity.HasKey(e => new { e.ApplicationId, e.Staffid, e.RoleId, e.FromDate }).HasName("sec_staff_roles_pkey");

            _=entity.ToTable("sec_staff_roles", "security");

            _=entity.HasIndex(e => new { e.ApplicationId, e.RoleId }, "sr_role_fk_i");

            _=entity.HasIndex(e => e.Staffid, "sr_user_1_fk_i");

            _=entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            _=entity.Property(e => e.Staffid).HasColumnName("staffid");
            _=entity.Property(e => e.RoleId)
                .HasMaxLength(30)
                .HasColumnName("role_id");
            _=entity.Property(e => e.FromDate)
                .HasMaxLength(10)
                .HasColumnName("from_date");
            _=entity.Property(e => e.AuthBy)
                .HasMaxLength(100)
                .HasColumnName("auth_by");
            _=entity.Property(e => e.AuthDate)
                .HasMaxLength(10)
                .HasColumnName("auth_date");
            _=entity.Property(e => e.AuthNo)
                .HasMaxLength(50)
                .HasColumnName("auth_no");
            _=entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            _=entity.Property(e => e.RoleSeq).HasColumnName("role_seq");
            _=entity.Property(e => e.ToDate)
                .HasMaxLength(10)
                .HasColumnName("to_date");
            _=entity.Property(e => e.TranDate)
                .HasMaxLength(10)
                .HasColumnName("tran_date");

            _=entity.HasOne(d => d.Application).WithMany(p => p.SecStaffRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_staff_roles_application_id_fkey");

            _=entity.HasOne(d => d.Staff).WithMany(p => p.SecStaffRoles)
                .HasForeignKey(d => d.Staffid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_staff_roles_staff_id_fkey");

            _=entity.HasOne(d => d.SecRole).WithMany(p => p.SecStaffRoles)
                .HasForeignKey(d => new { d.ApplicationId, d.RoleId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_staff_roles_fk");
        });

        modelBuilder.Entity<SecUser>(entity =>
        {
            _=entity.HasKey(e => e.UserId).HasName("sec_users_pkey");

            _=entity.ToTable("sec_users", "security");

            _=entity.Property(e => e.UserId).HasColumnName("user_id");
            _=entity.Property(e => e.AuthBy)
                .HasMaxLength(100)
                .HasColumnName("auth_by");
            _=entity.Property(e => e.AuthDate)
                .HasMaxLength(10)
                .HasColumnName("auth_date");
            _=entity.Property(e => e.AuthNo)
                .HasMaxLength(50)
                .HasColumnName("auth_no");
            entity.Property(e => e.Id).HasColumnName("Id");
            _=entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .HasColumnName("created_by");
            _=entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            _=entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            _=entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("ip_address");
            _=entity.Property(e => e.IsLoggedIn)
                .HasDefaultValue(false)
                .HasColumnName("is_logged_in");
            _=entity.Property(e => e.LastLoggedIn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_logged_in");
            _=entity.Property(e => e.LogInExpireTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("log_in_expire_time");
            _=entity.Property(e => e.Machine)
                .HasMaxLength(50)
                .HasColumnName("machine");
            _=entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasColumnName("remarks");
            _=entity.Property(e => e.Status)
                .HasMaxLength(5)
                .HasColumnName("status");
            _=entity.Property(e => e.Totalcredit)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("totalcredit");
            _=entity.Property(e => e.TranDate)
                .HasMaxLength(10)
                .HasColumnName("tran_date");
            _=entity.Property(e => e.UserName)
                .HasMaxLength(120)
                .HasColumnName("user_name");
            _=entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .HasColumnName("user_password");

            entity.HasOne(d => d.Cafe).WithMany(p => p.SecUsers)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sec_users_Id_fkey");
        });

        _=modelBuilder.Entity<SecUsersStatus>(entity =>
        {
            _=entity.HasKey(e => new { e.UserId, e.UserStatus, e.FromDate, e.SeqNo }).HasName("sec_users_status_pkey");

            _=entity.ToTable("sec_users_status", "security");

            _=entity.Property(e => e.UserId).HasColumnName("user_id");
            _=entity.Property(e => e.UserStatus)
                .HasMaxLength(1)
                .HasColumnName("user_status");
            _=entity.Property(e => e.FromDate)
                .HasColumnType("character varying")
                .HasColumnName("from_date");
            _=entity.Property(e => e.SeqNo).HasColumnName("seq_no");
            _=entity.Property(e => e.AuthBy)
                .HasMaxLength(100)
                .HasColumnName("auth_by");
            _=entity.Property(e => e.AuthDate)
                .HasMaxLength(10)
                .HasColumnName("auth_date");
            _=entity.Property(e => e.AuthNo)
                .HasMaxLength(50)
                .HasColumnName("auth_no");
            _=entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            _=entity.Property(e => e.EntryDate).HasColumnName("entry_date");
            _=entity.Property(e => e.ToDate)
                .HasMaxLength(10)
                .HasColumnName("to_date");

            _=entity.HasOne(d => d.User).WithMany(p => p.SecUsersStatuses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_users_status_user_id_fkey");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            _=entity.HasKey(e => e.Subscriptionid).HasName("subscriptions_pkey");

            _=entity.ToTable("subscriptions", "security");

            _=entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");
            entity.Property(e => e.EntryDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("EntryDate");
            _=entity.Property(e => e.Durationmonths).HasColumnName("durationmonths");
            _=entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            _=entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            _=entity.Property(e => e.Subscriptionname)
                .HasMaxLength(50)
                .HasColumnName("subscriptionname");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
