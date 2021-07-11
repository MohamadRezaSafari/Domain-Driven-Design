using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.ShiftAssignment
{
    public class EmptyShiftAssignedException:DomainException
    {
        public override string Message => ExceptionResource.EmptyShiftAssignedException;
    }
}
