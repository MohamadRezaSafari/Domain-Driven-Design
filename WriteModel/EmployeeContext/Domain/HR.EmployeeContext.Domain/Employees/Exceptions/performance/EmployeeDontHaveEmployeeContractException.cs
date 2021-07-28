using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.performance
{
    public class EmployeeDontHaveShiftAssignmentException : DomainException
    {
        public override string Message => ExceptionResource.EmployeeDontHaveShiftAssignmentException;
    }
}
