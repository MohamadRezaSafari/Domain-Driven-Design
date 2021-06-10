namespace Framework.Core.ApplicationService
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}