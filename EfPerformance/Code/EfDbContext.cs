using Microsoft.EntityFrameworkCore;

namespace EfPerformance.Code;

public class EfDbContext : DbContext
{
    private readonly string _connectionString;

    public EfDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<Job> Jobs { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (optionsBuilder.IsConfigured)
            return;

        optionsBuilder.UseSqlServer(_connectionString);
    }

}