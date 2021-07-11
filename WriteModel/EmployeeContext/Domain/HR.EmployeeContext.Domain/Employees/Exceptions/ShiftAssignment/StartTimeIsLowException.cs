using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.ShiftAssignment
{
    public class StartTimeIsLowException: DomainException
    {
        public override string Message => ExceptionResource.StartTimeIsLowException;
    }
}
