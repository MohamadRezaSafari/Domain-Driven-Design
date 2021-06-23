using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.ShiftAssignment
{
    public class EmptyShiftIdException: DomainException
    {
        public override string Message => ExceptionShiftAssignment.EmptyShiftIdException;
    }
}
