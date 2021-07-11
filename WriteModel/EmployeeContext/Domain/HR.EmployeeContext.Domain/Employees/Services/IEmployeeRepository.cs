using System;
using System.Linq.Expressions;
using Framework.Core.Persistence;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IEmployeeRepository : IRepository
    {
        void Create(Employee employee);
        void Update(Employee employee);
        Employee GetByEmployeeId(long employeeId);
        Employee GetShiftAssignmentByEmployeeId(long employeeId);
        ShiftAssignment GetLastShiftAssignmentByEmployeeId(long employeeId);
        bool Any(Expression<Func<Employee, bool>> expression);
        bool BoolHasShift(Expression<Func<ShiftAssignment, bool>> expression);
        void ShiftAssign(ShiftAssignment shiftAssignment);
    }
}
