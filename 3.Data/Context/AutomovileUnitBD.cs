using _3.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace _3.Data.Context;

public class AutomovileUnitBD : DbContext
{
    public AutomovileUnitBD()
    {

    }

    public AutomovileUnitBD(DbContextOptions<AutomovileUnitBD> options) : base(options)
    {
    }

    public DbSet<User> TUsers { get; set; }
    public DbSet<Automobile> TAutomobiles { get; set; }
    
    public DbSet<RequestRent> TRentRequests { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=root;Database=AutomovileUnit;", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("User");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(c => c.Lastname).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(c => c.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<User>().Property(c => c.IsActive).HasDefaultValue(true);

        builder.Entity<User>().Property(c => c.UserType).IsRequired();
        builder.Entity<User>().OwnsOne(p => p.Adress, location =>
        {
            location.Property(d => d.Department).IsRequired().HasMaxLength(50);
            location.Property(d => d.Province).IsRequired().HasMaxLength(50);
            location.Property(d => d.District).IsRequired().HasMaxLength(50);
            location.Property(d => d.Street).IsRequired().HasMaxLength(50);
        });
        
        builder.Entity<Automobile>(entity =>
        {
            entity.ToTable("Aumontovil");
            entity.HasKey(p => p.Id);
            entity.Property(c => c.Brand).IsRequired().HasMaxLength(50);
        });
        
        builder.Entity<RequestRent>(entity =>
        {
            entity.ToTable("RequestRent");
            entity.HasKey(p => p.Id);
            entity.Property(c => c.StatusRequest).IsRequired();
            entity.Property(c => c.DateCreated).HasDefaultValue(DateTime.Now);
            entity.Property(c => c.DateUpdate).HasDefaultValue(DateTime.Now);
        });
    }
}