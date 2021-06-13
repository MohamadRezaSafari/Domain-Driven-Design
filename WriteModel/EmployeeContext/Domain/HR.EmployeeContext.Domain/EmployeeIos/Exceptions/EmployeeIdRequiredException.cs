using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.EmployeeIos.Exceptions
{
    public class EmployeeIdRequiredException : DomainException
    {
        public override string Message => ExceptionResource.EmployeeIdRequiredException;
    }
}
