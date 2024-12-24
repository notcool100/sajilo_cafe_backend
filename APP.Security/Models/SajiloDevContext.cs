using APP.Security.Models.Menu;
using APP.Security.Models.Users;
using Microsoft.EntityFrameworkCore;
using APP.Cafe;
namespace APP.Security.Models;

public partial class SajiloDevContext : DbContext
{
    public SajiloDevContext()
    {
    }

    public SajiloDevContext(DbContextOptions<SajiloDevContext> options)
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
        modelBuilder.Entity<CafeM>(entity =>
        {
            entity.HasKey(e => e.Cafeid).HasName("cafe_pkey");

            entity.ToTable("cafe", "security");

            entity.Property(e => e.Cafeid).HasColumnName("cafeid");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CafeLogo).HasColumnName("cafe_logo");
            entity.Property(e => e.Cafename)
                .HasMaxLength(150)
                .HasColumnName("cafename");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

            entity.HasOne(d => d.Subscription).WithMany(p => p.Caves)
                .HasForeignKey(d => d.Subscriptionid)
                .HasConstraintName("cafe_subscriptionid_fkey");
        });

        modelBuilder.Entity<Cafestaff>(entity =>
        {
            entity.HasKey(e => e.Staffid).HasName("cafestaff_pkey");

            entity.ToTable("cafestaff", "security");

            entity.Property(e => e.Staffid).HasColumnName("staffid");
            entity.Property(e => e.Cafeid).HasColumnName("cafeid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Enddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Startdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Name)
               .HasColumnName("name");
            entity.Property(e => e.password)
               .HasColumnName("password");
            entity.Property(e => e.email)
                .HasColumnName("email");
            entity.Property(e => e.phoneNo)
                .HasColumnName("phoneno");

            entity.HasOne(d => d.Cafe).WithMany(p => p.Cafestaffs)
                .HasForeignKey(d => d.Cafeid)
                .HasConstraintName("cafestaff_cafeid_fkey");
           
        });

        modelBuilder.Entity<ClkStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("clk_status_pk");

            entity.ToTable("clk_status", "security");

            entity.HasIndex(e => e.StatusDesc, "clk_status_un").IsUnique();

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(0)
                .HasColumnName("is_active");
            entity.Property(e => e.IsVerif)
                .HasDefaultValue(false)
                .HasColumnName("is_verif");
            entity.Property(e => e.StatusDesc)
                .HasColumnType("character varying")
                .HasColumnName("status_desc");
            entity.Property(e => e.VerifDesc)
                .HasMaxLength(100)
                .HasColumnName("verif_desc");
        });

        modelBuilder.Entity<Credittransaction>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("credittransactions_pkey");

            entity.ToTable("credittransactions", "account");

            entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Cafeid).HasColumnName("cafeid");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Transactiondate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transactiondate");
            entity.Property(e => e.Transactiontype)
                .HasMaxLength(50)
                .HasColumnName("transactiontype");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<SecApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("sec_applications_pkey");

            entity.ToTable("sec_applications", "security");

            entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            entity.Property(e => e.ApplicationDescription)
                .HasMaxLength(100)
                .HasColumnName("application_description");
            entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");
            entity.Property(e => e.OrderCode).HasColumnName("order_code");
        });

        modelBuilder.Entity<SecFunction>(entity =>
        {
            entity.HasKey(e => e.FunCd).HasName("sec_functions_pkey");

            entity.ToTable("sec_functions", "security");

            entity.HasIndex(e => e.StatusId, "uk_functions_status_id").IsUnique();

            entity.Property(e => e.FunCd)
                .HasMaxLength(2)
                .HasColumnName("fun_cd");
            entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");
            entity.Property(e => e.FunDesc)
                .HasMaxLength(10)
                .HasColumnName("fun_desc");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Status).WithOne(p => p.SecFunction)
                .HasForeignKey<SecFunction>(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_functions_status_id");
        });

        modelBuilder.Entity<SecMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("sec_menu_pkey");

            entity.ToTable("sec_menu", "security");

            entity.Property(e => e.MenuId)
                .ValueGeneratedNever()
                .HasColumnName("menu_id");
            entity.Property(e => e.HasChild)
                .HasMaxLength(1)
                .HasColumnName("has_child");
            entity.Property(e => e.MUrl)
                .HasMaxLength(200)
                .HasColumnName("m_url");
            entity.Property(e => e.MenuIcon)
                .HasMaxLength(100)
                .HasColumnName("menu_icon");
            entity.Property(e => e.MenuText)
                .HasMaxLength(50)
                .HasColumnName("menu_text");
            entity.Property(e => e.OrderNo).HasColumnName("order_no");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.SecApl)
                .HasMaxLength(1)
                .HasColumnName("sec_apl");
            entity.Property(e => e.ToolTip)
                .HasMaxLength(100)
                .HasColumnName("tool_tip");
            entity.Property(e => e.UsedIn)
                .HasMaxLength(4)
                .HasColumnName("used_in");
        });

        modelBuilder.Entity<SecModule>(entity =>
        {
            entity.HasKey(e => new { e.ApplicationId, e.ModuleId }).HasName("sec_modules_pkey");

            entity.ToTable("sec_modules", "security");

            entity.HasIndex(e => e.ApplicationId, "module_app_fk_i");

            entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            entity.Property(e => e.ModuleId)
                .HasMaxLength(50)
                .HasColumnName("module_id");
            entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MOrderCode).HasColumnName("m_order_code");
            entity.Property(e => e.McRestricted)
                .HasMaxLength(1)
                .HasColumnName("mc_restricted");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.MenuName)
                .HasMaxLength(100)
                .HasColumnName("menu_name");
            entity.Property(e => e.ModuleDescription)
                .HasMaxLength(120)
                .HasColumnName("module_description");
            entity.Property(e => e.ModuleType)
                .HasMaxLength(1)
                .HasColumnName("module_type");
            entity.Property(e => e.UsesBy)
                .HasMaxLength(4)
                .HasColumnName("uses_by");

            entity.HasOne(d => d.Application).WithMany(p => p.SecModules)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_modules_application_id_fkey");

            entity.HasOne(d => d.Menu).WithMany(p => p.SecModules)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("sec_modules_menu_id_fkey");
        });

        modelBuilder.Entity<SecModuleFunction>(entity =>
        {
            entity.HasKey(e => new { e.ApplicationId, e.ModuleId, e.FunCd }).HasName("sec_module_functions_pkey");

            entity.ToTable("sec_module_functions", "security");

            entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            entity.Property(e => e.ModuleId)
                .HasMaxLength(50)
                .HasColumnName("module_id");
            entity.Property(e => e.FunCd)
                .HasMaxLength(2)
                .HasColumnName("fun_cd");
            entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");

            entity.HasOne(d => d.Application).WithMany(p => p.SecModuleFunctions)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_module_functions_application_id_fkey1");

            entity.HasOne(d => d.FunCdNavigation).WithMany(p => p.SecModuleFunctions)
                .HasForeignKey(d => d.FunCd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_module_functions_fun_cd_fkey");

            entity.HasOne(d => d.SecModule).WithMany(p => p.SecModuleFunctions)
                .HasForeignKey(d => new { d.ApplicationId, d.ModuleId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_module_functions_fk");
        });

        modelBuilder.Entity<SecRole>(entity =>
        {
            entity.HasKey(e => new { e.ApplicationId, e.RoleId }).HasName("sec_roles_pkey");

            entity.ToTable("sec_roles", "security");

            entity.HasIndex(e => e.ApplicationId, "role_app_fk_i");

            entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            entity.Property(e => e.RoleId)
                .HasMaxLength(30)
                .HasColumnName("role_id");
            entity.Property(e => e.DbRole)
                .HasMaxLength(30)
                .HasColumnName("db_role");
            entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            entity.Property(e => e.EntryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("entry_date");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(120)
                .HasColumnName("role_description");

            entity.HasOne(d => d.Application).WithMany(p => p.SecRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_roles_application_id_fkey");
        });

        modelBuilder.Entity<SecStaffRole>(entity =>
        {
            entity.HasKey(e => new { e.ApplicationId, e.Staffid, e.RoleId, e.FromDate }).HasName("sec_staff_roles_pkey");

            entity.ToTable("sec_staff_roles", "security");

            entity.HasIndex(e => new { e.ApplicationId, e.RoleId }, "sr_role_fk_i");

            entity.HasIndex(e => e.Staffid, "sr_user_1_fk_i");

            entity.Property(e => e.ApplicationId)
                .HasMaxLength(20)
                .HasColumnName("application_id");
            entity.Property(e => e.Staffid).HasColumnName("staffid");
            entity.Property(e => e.RoleId)
                .HasMaxLength(30)
                .HasColumnName("role_id");
            entity.Property(e => e.FromDate)
                .HasMaxLength(10)
                .HasColumnName("from_date");
            entity.Property(e => e.AuthBy)
                .HasMaxLength(100)
                .HasColumnName("auth_by");
            entity.Property(e => e.AuthDate)
                .HasMaxLength(10)
                .HasColumnName("auth_date");
            entity.Property(e => e.AuthNo)
                .HasMaxLength(50)
                .HasColumnName("auth_no");
            entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            entity.Property(e => e.RoleSeq).HasColumnName("role_seq");
            entity.Property(e => e.ToDate)
                .HasMaxLength(10)
                .HasColumnName("to_date");
            entity.Property(e => e.TranDate)
                .HasMaxLength(10)
                .HasColumnName("tran_date");

            entity.HasOne(d => d.Application).WithMany(p => p.SecStaffRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_staff_roles_application_id_fkey");

            entity.HasOne(d => d.Staff).WithMany(p => p.SecStaffRoles)
                .HasForeignKey(d => d.Staffid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_staff_roles_staff_id_fkey");

            entity.HasOne(d => d.SecRole).WithMany(p => p.SecStaffRoles)
                .HasForeignKey(d => new { d.ApplicationId, d.RoleId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_staff_roles_fk");
        });

        modelBuilder.Entity<SecUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("sec_users_pkey");

            entity.ToTable("sec_users", "security");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AuthBy)
                .HasMaxLength(100)
                .HasColumnName("auth_by");
            entity.Property(e => e.AuthDate)
                .HasMaxLength(10)
                .HasColumnName("auth_date");
            entity.Property(e => e.AuthNo)
                .HasMaxLength(50)
                .HasColumnName("auth_no");
            entity.Property(e => e.Cafeid).HasColumnName("cafeid");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("ip_address");
            entity.Property(e => e.IsLoggedIn)
                .HasDefaultValue(false)
                .HasColumnName("is_logged_in");
            entity.Property(e => e.LastLoggedIn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_logged_in");
            entity.Property(e => e.LogInExpireTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("log_in_expire_time");
            entity.Property(e => e.Machine)
                .HasMaxLength(50)
                .HasColumnName("machine");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasColumnName("remarks");
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .HasColumnName("status");
            entity.Property(e => e.Totalcredit)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("totalcredit");
            entity.Property(e => e.TranDate)
                .HasMaxLength(10)
                .HasColumnName("tran_date");
            entity.Property(e => e.UserName)
                .HasMaxLength(120)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .HasColumnName("user_password");

            entity.HasOne(d => d.Cafe).WithMany(p => p.SecUsers)
                .HasForeignKey(d => d.Cafeid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sec_users_cafeid_fkey");
        });

        modelBuilder.Entity<SecUsersStatus>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.UserStatus, e.FromDate, e.SeqNo }).HasName("sec_users_status_pkey");

            entity.ToTable("sec_users_status", "security");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserStatus)
                .HasMaxLength(1)
                .HasColumnName("user_status");
            entity.Property(e => e.FromDate)
                .HasColumnType("character varying")
                .HasColumnName("from_date");
            entity.Property(e => e.SeqNo).HasColumnName("seq_no");
            entity.Property(e => e.AuthBy)
                .HasMaxLength(100)
                .HasColumnName("auth_by");
            entity.Property(e => e.AuthDate)
                .HasMaxLength(10)
                .HasColumnName("auth_date");
            entity.Property(e => e.AuthNo)
                .HasMaxLength(50)
                .HasColumnName("auth_no");
            entity.Property(e => e.EntryBy)
                .HasMaxLength(30)
                .HasColumnName("entry_by");
            entity.Property(e => e.EntryDate).HasColumnName("entry_date");
            entity.Property(e => e.ToDate)
                .HasMaxLength(10)
                .HasColumnName("to_date");

            entity.HasOne(d => d.User).WithMany(p => p.SecUsersStatuses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sec_users_status_user_id_fkey");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Subscriptionid).HasName("subscriptions_pkey");

            entity.ToTable("subscriptions", "security");

            entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Durationmonths).HasColumnName("durationmonths");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Subscriptionname)
                .HasMaxLength(50)
                .HasColumnName("subscriptionname");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
