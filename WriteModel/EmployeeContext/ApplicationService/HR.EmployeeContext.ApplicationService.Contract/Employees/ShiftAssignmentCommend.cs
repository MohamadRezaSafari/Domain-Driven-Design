using System;
using Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class ShiftAssignmentCommend : Command
    {
        public long EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid ShiftId { get; set; }
    }
}
