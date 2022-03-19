using System;
using System.Linq;
using Dapper;
using FluentAssertions;
using Xunit;

namespace EfPerformance.Tests;

public class EfTests : DbTestBase
{
    [Fact]
    void reads_jobs()
    {
        var id = Guid.NewGuid();
        SqlConnection.Execute("INSERT INTO Jobs(Id, LastUpdatedAt) VALUES (@id, @date)", new { Id = id, Date = new DateTime(2001, 1, 1) });

        var actual = DbContext.Jobs.Single();

        actual.Id.Should().Be(id);
        actual.LastUpdatedAt.Should().Be(new DateTime(2001, 1, 1));
    }   
}