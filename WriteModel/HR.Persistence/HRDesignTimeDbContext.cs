using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HR.Persistence
{
    public class HRDesignTimeDbContext : IDesignTimeDbContextFactory<HRDbContext>
    {
        public HRDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRDbContext>();
            optionsBuilder.UseSqlServer("Data Source = 192.168.2.252; Initial Catalog = HR_Developer; User Id = saleadmin; Password = 123");

            return new HRDbContext(optionsBuilder.Options);
        }
    }
}
