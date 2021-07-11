using System;
using Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contract.Employees
{
    public class ShiftAssignmentCommend : Command
    {
        public long EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public Guid ShiftSegmentId { get; set; }
    }
}
