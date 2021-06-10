using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence
{
    public abstract class DbContextBase : DbContext, IDbContext
    {
        protected DbContextBase(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        public void Migrate()
        {
            base.Database.Migrate();
        }
    }

}
