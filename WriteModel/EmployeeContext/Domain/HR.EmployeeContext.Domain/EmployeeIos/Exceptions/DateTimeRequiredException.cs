using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.EmployeeIos.Exceptions
{
    public class DateTimeRequiredException : DomainException
    {
        public override string Message => ExceptionResource.DateTimeRequiredException;
    }
}
