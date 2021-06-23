using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.Employee
{
    public class FirstNameRequiredException : DomainException
    {
        public override string Message => ExceptionResource.FirstNameRequiredException;
    }
}
