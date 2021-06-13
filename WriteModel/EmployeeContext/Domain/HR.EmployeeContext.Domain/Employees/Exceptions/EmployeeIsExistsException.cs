using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class EmployeeIsExistsException : DomainException
    {
        public override string Message => ExceptionResource.EmployeeIsExistsException;
    }
}
