using Framework.Core.Persistence;

namespace HR.EmployeeContext.Domain.EmployeeIos.Services
{
    public interface IEmployeeIORepository:IRepository
    {
        void Create(EmployeeIo employeeIo);
    }
}
