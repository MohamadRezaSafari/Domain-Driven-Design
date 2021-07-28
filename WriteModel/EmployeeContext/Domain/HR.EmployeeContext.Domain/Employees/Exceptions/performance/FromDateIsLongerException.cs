using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.performance
{
    public class FromDateIsLongerException: DomainException
    {
        public override string Message => ExceptionResource.FromDateIsLongerException;
    }
}
