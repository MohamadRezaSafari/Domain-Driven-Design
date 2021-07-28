using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.performance
{
    public class EmployeeIdIsRequiredException: DomainException
    {
        public override string Message => ExceptionResource.EmployeeIdIsRequiredException;
    }
}
