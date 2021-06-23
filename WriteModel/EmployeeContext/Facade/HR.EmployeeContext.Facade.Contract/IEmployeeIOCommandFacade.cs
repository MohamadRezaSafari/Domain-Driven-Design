
using HR.EmployeeContext.ApplicationService.Contract.EmployeeIos;

namespace HR.EmployeeContext.Facade.Contract
{
    public interface IEmployeeIOCommandFacade
    {

        void CreateEmployeeIO(EmployeeIOCreateCommand command);
        
    }
}
