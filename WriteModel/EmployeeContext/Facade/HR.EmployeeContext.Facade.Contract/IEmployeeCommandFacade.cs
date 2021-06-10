using Framework.Core.Facade;
using HR.EmployeeContext.ApplicationService.Contract.Employees;

namespace HR.EmployeeContext.Facade.Contract
{
    public interface IEmployeeCommandFacade
    {
        void CreateEmployee(EmployeeCreateCommand command);
    }
}