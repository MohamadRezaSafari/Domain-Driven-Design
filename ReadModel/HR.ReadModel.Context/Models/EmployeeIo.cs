using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class EmployeeIo
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
