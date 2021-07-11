using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.Employee
{
    public class ShiftIdNotExistsException:DomainException
    {
        public override string Message => ExceptionResource.ShiftIdNotExistsException;
    }
}
