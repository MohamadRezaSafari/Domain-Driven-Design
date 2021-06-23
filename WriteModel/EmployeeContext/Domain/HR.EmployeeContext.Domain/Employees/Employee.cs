using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Core.Domain;
using Framework.Domain;
using HR.EmployeeContext.Domain.EmployeeIos;
using HR.EmployeeContext.Domain.Employees.Exceptions.Employee;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Employees
{
    public class Employee : EntityBase, IAggregateRoot
    {
        protected Employee() { }

        public Employee(string firstName, string lastName)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
        }

        public void UpdateEmployee(IEmployeeIsExists employeeIsExists,
            IEmployeeHasShift employeeHasShift,
            string firstName,
            string lastName)
        {
            if (!employeeIsExists.IsExists(this.EmployeeId))
            {
                throw new EmployeeIsExistsException();
            }

            if (!string.IsNullOrWhiteSpace(firstName))
                SetFirstName(firstName);
            if (!string.IsNullOrWhiteSpace(lastName))
                SetLastName(lastName);

        }

        public void DeleteEmployee(IEmployeeIsExists employeeIsExists)
        {
            if (!employeeIsExists.IsExists(this.EmployeeId))
            {
                throw new EmployeeIsExistsException();
            }
            IsActive = false;
        }


        private void SetFirstName(string firstName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
                throw new FirstNameRequiredException();

            FirstName = firstName;
        }


        private void SetLastName(string lastName)
        {
            if (String.IsNullOrWhiteSpace(lastName))
                throw new LastNameRequiredException();

            LastName = lastName;
        }

        // TODO
        public long EmployeeId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsActive { get; set; }

        public ICollection<ShiftAssignment> ShiftAssignments { set; get; } = new HashSet<ShiftAssignment>();
        public ICollection<EmployeeIo> EmployeeIos { set; get; } = new HashSet<EmployeeIo>();
        //public HashSet<ShiftAssignment> ShiftAssignment { get; set; } = new HashSet<ShiftAssignment>();


        public void AddEmployeeIo(EmployeeIo employeeIo)
        {
            EmployeeIos.Add(employeeIo);
        }


        public void AssignShift(IEmployeeHasShift employeeHasShift, ShiftAssignment shiftAssignment)
        {
            //if (employeeHasShift.HasShift(this.EmployeeId))
            //{

            //    //Todo
            //}
            ShiftAssignments.Add(shiftAssignment);
            //ShiftAssignment.Add(shiftAssignment);

            //ShiftAssignments.Add(shiftAssignment);
        }

        public IEnumerable<Expression<Func<Employee, object>>> GetAggregateExpressions()
        {
            //yield return null;
            yield return e => e.ShiftAssignments;
        }
    }
}
