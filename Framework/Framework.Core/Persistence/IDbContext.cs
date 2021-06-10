using System;

namespace Framework.Persistence
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        void Migrate();
    }
}
