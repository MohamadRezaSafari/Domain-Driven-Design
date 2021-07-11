using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.EmployeeIo
{
    public class EmployeeIdRequiredException : DomainException
    {
        public override string Message => ExceptionResource.EmployeeIdRequiredException;
    }
}
