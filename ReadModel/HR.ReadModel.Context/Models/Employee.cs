using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class Employee
    {
        public Guid Id { get; set; }
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
    }
}
