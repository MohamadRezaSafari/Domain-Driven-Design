using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HR.Persistence
{
    public class HRDesignTimeDbContext : IDesignTimeDbContextFactory<HRDbContext>
    {
        public HRDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRDbContext>();
            optionsBuilder.UseSqlServer("Data Source=192.168.62.142;Initial Catalog=HR_Developer; ;User Id=saleadmin;Password=990002;");

            return new HRDbContext(optionsBuilder.Options);
        }
    }
}
