using Microsoft.EntityFrameworkCore.Design;

namespace EfPerformance.Code;

public class DbContextDesignFactory : IDesignTimeDbContextFactory<EfDbContext>
{
    public EfDbContext CreateDbContext(string[] args)
    {
        return new EfDbContext("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=True;Connect Timeout=30;Encrypt=False;");
    }
}