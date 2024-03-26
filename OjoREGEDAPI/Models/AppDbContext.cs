namespace OjoREGEDAPI.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeLocation> EmployeeLocations { get; set; }

    public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderPlaced> OrderPlaceds { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Pickup> Pickups { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SubcriptionsLevel> SubcriptionsLevels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\BSISQLEXPRESS;Initial Catalog=OjoREGED;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Customer");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillsId).HasName("PK_Bills_ID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bills_Customer");

            entity.HasOne(d => d.Pickup).WithMany(p => p.Bills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bills_Pickup");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.SubscriptionId).HasDefaultValue(1);

            entity.HasOne(d => d.Role).WithMany(p => p.Customers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Role");

            entity.HasOne(d => d.Subscription).WithMany(p => p.Customers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Subcriptions_Level");
        });

        modelBuilder.Entity<CustomerSubscription>(entity =>
        {
            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Subscription_Customer");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Role");
        });

        modelBuilder.Entity<EmployeeLocation>(entity =>
        {
            entity.Property(e => e.Latitude).IsFixedLength();

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Location_Employee");
        });

        modelBuilder.Entity<EmployeeSchedule>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Schedule_Employee");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.OrderStatus).HasDefaultValue(1);
            entity.Property(e => e.Size).IsFixedLength();

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Detail_Order_Placed");

            entity.HasOne(d => d.OrderStatusNavigation).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Detail_Order_Status");
        });

        modelBuilder.Entity<OrderPlaced>(entity =>
        {
            entity.Property(e => e.TimePlaced).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderPlaceds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Placed_Customer");

            entity.HasOne(d => d.EmployeeSchedule).WithMany(p => p.OrderPlaceds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Placed_Employee_Schedule");
        });

        modelBuilder.Entity<Pickup>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.Pickups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pickup_Employee");

            entity.HasOne(d => d.Order).WithMany(p => p.Pickups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pickup_Order_Placed");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
