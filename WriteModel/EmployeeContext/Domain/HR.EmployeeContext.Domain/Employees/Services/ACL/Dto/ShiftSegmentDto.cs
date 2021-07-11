using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.EmployeeContext.Domain.Employees.Services.ACL.Dto
{
    public class ShiftSegmentDto
    {
        public Guid Id { get; set; }
        public Guid ShiftId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid? NextShiftId { get; set; }
    }
}
