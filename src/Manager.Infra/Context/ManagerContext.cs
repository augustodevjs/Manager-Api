using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context;

public class ManagerContext : DbContext
{
    public ManagerContext() {}
    
    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) {}

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            "Server=localhost;port=3306;Database=user;Uid=root;Pwd=84880897; Connection Timeout=30; Persist Security Info=False";

        var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));

        optionsBuilder.UseMySql(connectionString, serverVersion, options =>
        {
            options.EnableRetryOnFailure();
        });
    }
}