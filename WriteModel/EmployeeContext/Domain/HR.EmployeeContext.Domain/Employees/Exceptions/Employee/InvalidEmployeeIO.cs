using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.Employee
{
    public class InvalidEmployeeIO:DomainException

    {
        public override string Message => ExceptionResource.InvalidEmployeeIO;
    }
}
