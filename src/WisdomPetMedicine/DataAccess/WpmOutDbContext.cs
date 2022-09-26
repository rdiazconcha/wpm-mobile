using Microsoft.EntityFrameworkCore;

namespace WisdomPetMedicine.DataAccess;
public class WpmOutDbContext : DbContext
{
    private readonly IPath path;
    public DbSet<Sale> Sales { get; set; }

    public WpmOutDbContext(IPath path, DbContextOptions<WpmOutDbContext> options)
        : base(options)
    {
        this.path = path;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = $"Filename={path.GetDatabasePath()}";
        optionsBuilder.UseSqlite(connectionString);
    }
}
public record Sale(int ClientId, int ProductId, int Quantity, decimal Amount)
{
    public int Id { get; set; }
}