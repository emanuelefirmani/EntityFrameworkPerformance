using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EfPerformance.Code;

internal class Updater
{
    private readonly EfDbContext _context;

    internal Updater(EfDbContext context)
    {
        _context = context;
    }

    internal List<long> UpdateAllJobs(DateTime minRefreshDate)
    {
        var output = new List<long>();
        
        foreach (var id in _context.Jobs.Where(x => x.LastUpdatedAt < minRefreshDate).Select(x => x.Id).ToList())
        {
            var job = _context.Jobs.Single(x => x.Id == id);
            job.LastUpdatedAt = DateTime.Now;

            var sw = Stopwatch.StartNew();
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            sw.Stop();
            
            output.Add(sw.ElapsedMilliseconds);
        }

        return output;
    }
}