using Dapper;
using EfPerformance.Code;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfPerformance.Tests;

[Collection("DB integration tests")]
public class DbTestBase
{
    protected EfDbContext DbContext { get; }
    protected SqlConnection SqlConnection { get; }

    internal DbTestBase()
    {
        SqlConnection = new SqlConnection(Constants.DbConnectionString);
        DbContext = new EfDbContext(Constants.DbConnectionString);
    }
}

[CollectionDefinition("DB integration tests")]
public class TestCollection : ICollectionFixture<Fixture>
{ }

public class Fixture
{
    public Fixture()
    {
        using (var conn = new SqlConnection(Constants.InstanceConnectionString))
        {
            conn.Execute(
                $"IF EXISTS(SELECT database_id FROM sys.databases WHERE Name = '{Constants.DbName}') BEGIN" +
                $"     ALTER DATABASE [{Constants.DbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" +
                $"     DROP DATABASE [{Constants.DbName}];" +
                "END");
        }

        new EfDbContext(Constants.DbConnectionString).Database.Migrate();
    }
}