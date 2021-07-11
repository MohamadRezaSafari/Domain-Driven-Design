using System;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContext dbContext) : base(dbContext)
        {
            
        }

        public void Create(Employee employee)
        {
            base.Create(employee);
        }
        
        public void Update(Employee employee)
        {
            base.Update(employee);
        }

        public Employee GetByEmployeeId(long employeeId)
        {
            //return base.Set.SingleOrDefault(e => e.EmployeeId == employeeId);
            return dbContext.Set<Employee>().Include(e => e.ShiftAssignments).Include(e=>e.EmployeeIos).Include(e=>e.EmployeeContracts).SingleOrDefault(e => e.EmployeeId == employeeId);
        }
        public Employee GetShiftAssignmentByEmployeeId(long employeeId)
        {
            return dbContext.Set<Employee>().Include(e=>e.ShiftAssignments).SingleOrDefault(e => e.EmployeeId == employeeId);
            
        }

        public ShiftAssignment GetLastShiftAssignmentByEmployeeId(long employeeId)
        {
            var employee= dbContext.Set<Employee>().Include(e => e.ShiftAssignments).SingleOrDefault(e => e.EmployeeId == employeeId);
            return employee.ShiftAssignments.OrderByDescending(e => e.StartDate).FirstOrDefault();


        }

        public bool Any(Expression<Func<Employee, bool>> expression)
        {
            return dbContext.Set<Employee>().Any(expression);
        }

        public bool BoolHasShift(Expression<Func<ShiftAssignment, bool>> expression)
        {
            return dbContext.Set<ShiftAssignment>().Any(expression);
        }

        public Employee GetByEmployeeById(Guid id)
        {
            return dbContext.Set<Employee>().Single(e => e.Id == id);
        }

        public void ShiftAssign(ShiftAssignment shiftAssignment)
        {
           // base.Create(shiftAssignment);
        }


        protected override IEnumerable<Expression<Func<Employee, object>>> GetAggregateExpression()
        {
            yield return e => e.ShiftAssignments;
            yield return e => e.EmployeeContracts;
        }
    }
}
