using Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IEmployeeHasShiftAssignment:IDomainService
    {
        bool HasEmployeeShiftAssign(long employeeId);
    }
}
