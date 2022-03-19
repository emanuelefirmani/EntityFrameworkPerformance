using System;
using System.Linq;
using Dapper;
using EfPerformance.Code;
using FluentAssertions;
using Xunit;

namespace EfPerformance.Tests;

public class PerformanceTests : DbTestBase
{
    private const int PropLenght = 20;
    private static readonly Random Random = new();
    
    [Fact]
    void loop_creates_any_number_of_jobs()
    {
        CreateJobs(5);

        DbContext.Jobs.Count().Should().Be(5);
    }

    private void CreateJobs(int countOfJobs)
    {
        for (var i = 0; i < countOfJobs; i++)
        {
            var id = Guid.NewGuid();
            SqlConnection.Execute("INSERT INTO Jobs(Id, LastUpdatedAt, Prop0, Prop1, Prop2, Prop3, Prop4, Prop5, Prop6, Prop7, Prop8, Prop9, Prop10, Prop11, Prop12, Prop13, Prop14, Prop15, Prop16, Prop17, Prop18, Prop19, Prop20, Prop21, Prop22, Prop23, Prop24, Prop25, Prop26, Prop27, Prop28, Prop29, Prop30, Prop31, Prop32, Prop33, Prop34, Prop35, Prop36, Prop37, Prop38, Prop39, Prop40, Prop41, Prop42, Prop43, Prop44, Prop45, Prop46, Prop47, Prop48, Prop49, Prop50, Prop51, Prop52, Prop53, Prop54, Prop55, Prop56, Prop57, Prop58, Prop59, Prop60, Prop61, Prop62, Prop63, Prop64, Prop65, Prop66, Prop67, Prop68, Prop69, Prop70, Prop71, Prop72, Prop73, Prop74, Prop75, Prop76, Prop77, Prop78, Prop79)" + 
                                  "VALUES (@id, @LastUpdatedAt, @Prop0, @Prop1, @Prop2, @Prop3, @Prop4, @Prop5, @Prop6, @Prop7, @Prop8, @Prop9, @Prop10, @Prop11, @Prop12, @Prop13, @Prop14, @Prop15, @Prop16, @Prop17, @Prop18, @Prop19, @Prop20, @Prop21, @Prop22, @Prop23, @Prop24, @Prop25, @Prop26, @Prop27, @Prop28, @Prop29, @Prop30, @Prop31, @Prop32, @Prop33, @Prop34, @Prop35, @Prop36, @Prop37, @Prop38, @Prop39, @Prop40, @Prop41, @Prop42, @Prop43, @Prop44, @Prop45, @Prop46, @Prop47, @Prop48, @Prop49, @Prop50, @Prop51, @Prop52, @Prop53, @Prop54, @Prop55, @Prop56, @Prop57, @Prop58, @Prop59, @Prop60, @Prop61, @Prop62, @Prop63, @Prop64, @Prop65, @Prop66, @Prop67, @Prop68, @Prop69, @Prop70, @Prop71, @Prop72, @Prop73, @Prop74, @Prop75, @Prop76, @Prop77, @Prop78, @Prop79)", 
                new Job {Id = id, LastUpdatedAt = new DateTime(2001, 1, 1), Prop0 = GenerateRandomString(), Prop1 = GenerateRandomString(), Prop2 = GenerateRandomString(), Prop3 = GenerateRandomString(), Prop4 = GenerateRandomString(), Prop5 = GenerateRandomString(), Prop6 = GenerateRandomString(), Prop7 = GenerateRandomString(), Prop8 = GenerateRandomString(), Prop9 = GenerateRandomString(), Prop10 = GenerateRandomString(), Prop11 = GenerateRandomString(), Prop12 = GenerateRandomString(), Prop13 = GenerateRandomString(), Prop14 = GenerateRandomString(), Prop15 = GenerateRandomString(), Prop16 = GenerateRandomString(), Prop17 = GenerateRandomString(), Prop18 = GenerateRandomString(), Prop19 = GenerateRandomString(), Prop20 = GenerateRandomString(), Prop21 = GenerateRandomString(), Prop22 = GenerateRandomString(), Prop23 = GenerateRandomString(), Prop24 = GenerateRandomString(), Prop25 = GenerateRandomString(), Prop26 = GenerateRandomString(), Prop27 = GenerateRandomString(), Prop28 = GenerateRandomString(), Prop29 = GenerateRandomString(), Prop30 = GenerateRandomString(), Prop31 = GenerateRandomString(), Prop32 = GenerateRandomString(), Prop33 = GenerateRandomString(), Prop34 = GenerateRandomString(), Prop35 = GenerateRandomString(), Prop36 = GenerateRandomString(), Prop37 = GenerateRandomString(), Prop38 = GenerateRandomString(), Prop39 = GenerateRandomString(), Prop40 = GenerateRandomString(), Prop41 = GenerateRandomString(), Prop42 = GenerateRandomString(), Prop43 = GenerateRandomString(), Prop44 = GenerateRandomString(), Prop45 = GenerateRandomString(), Prop46 = GenerateRandomString(), Prop47 = GenerateRandomString(), Prop48 = GenerateRandomString(), Prop49 = GenerateRandomString(), Prop50 = GenerateRandomString(), Prop51 = GenerateRandomString(), Prop52 = GenerateRandomString(), Prop53 = GenerateRandomString(), Prop54 = GenerateRandomString(), Prop55 = GenerateRandomString(), Prop56 = GenerateRandomString(), Prop57 = GenerateRandomString(), Prop58 = GenerateRandomString(), Prop59 = GenerateRandomString(), Prop60 = GenerateRandomString(), Prop61 = GenerateRandomString(), Prop62 = GenerateRandomString(), Prop63 = GenerateRandomString(), Prop64 = GenerateRandomString(), Prop65 = GenerateRandomString(), Prop66 = GenerateRandomString(), Prop67 = GenerateRandomString(), Prop68 = GenerateRandomString(), Prop69 = GenerateRandomString(), Prop70 = GenerateRandomString(), Prop71 = GenerateRandomString(), Prop72 = GenerateRandomString(), Prop73 = GenerateRandomString(), Prop74 = GenerateRandomString(), Prop75 = GenerateRandomString(), Prop76 = GenerateRandomString(), Prop77 = GenerateRandomString(), Prop78 = GenerateRandomString(), Prop79 = GenerateRandomString()});
        }
    }

    private string GenerateRandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, PropLenght)
            .Select(s => s[Random.Next(s.Length)]).ToArray());    }
}