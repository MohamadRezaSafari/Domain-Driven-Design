using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.EmployeeIo
{
    public class DateTimeRequiredException : DomainException
    {
        public override string Message => ExceptionResource.DateTimeRequiredException;
    }
}
