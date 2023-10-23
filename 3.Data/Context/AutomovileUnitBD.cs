using _3.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace _3.Data.Context;

public class AutomovileUnitBD: DbContext
{
    public AutomovileUnitBD()
    {
        
    }
    public AutomovileUnitBD(DbContextOptions<AutomovileUnitBD> options) : base(options)
    {
    }
    public DbSet<User> TUsers{ get; set; }
    
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
    }
}