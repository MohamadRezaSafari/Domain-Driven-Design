using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.ShiftAssignment
{
    public class ShiftIdDontExistException : DomainException
    {
        public override string Message => ExceptionResource.ShiftIdDontExistException;
    }
}
