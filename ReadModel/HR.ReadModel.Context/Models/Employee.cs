using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeContracts = new HashSet<EmployeeContract>();
            EmployeeIos = new HashSet<EmployeeIo>();
            ShiftAssignments = new HashSet<ShiftAssignment>();
        }

        public Guid Id { get; set; }
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? SettlementDate { get; set; }
        public Guid? UnitId { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }
        public virtual ICollection<EmployeeIo> EmployeeIos { get; set; }
        public virtual ICollection<ShiftAssignment> ShiftAssignments { get; set; }
    }
}
