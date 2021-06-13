using Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IEmployeeIsExists: IDomainService
    {
        bool IsExists(long EmployeeId);
    }
}