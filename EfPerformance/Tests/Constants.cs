namespace EfPerformance.Tests;

internal static class Constants
{
    internal const string DbName = "EfPerformance";
    internal const string DbConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=" + DbName + "; Integrated Security=True;Connect Timeout=30;Encrypt=False";
    internal const string InstanceConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=True;Connect Timeout=30;Encrypt=False";
}