using Framework.AssemblyHelper;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.Persistence
{
    public class HRDbContext : DbContextBase
    {
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityMapping = DetectEntityMapping();

            entityMapping.ForEach(a =>
            {
                modelBuilder.ApplyConfiguration(a);

            });
        }


        protected List<dynamic> DetectEntityMapping()
        {
            var assemblyHelper = new AssemblyDiscovery("HR*.dll");
            var getType = assemblyHelper.DiscoverTypes<IEntityMapping>("HR")
                .Select(Activator.CreateInstance)
                .Cast<dynamic>()
                .ToList();

            return getType;
        }
    }
}
