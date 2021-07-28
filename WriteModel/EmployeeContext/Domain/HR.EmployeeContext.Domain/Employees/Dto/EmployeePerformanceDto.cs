using System;

namespace HR.EmployeeContext.Domain.Employees.Dto
{
    public class EmployeePerformanceDto
    {
        public Guid EmployeeId { get; set; }
        public Guid ShiftSegmentId { get; set; }
        public Guid ShiftId { get; set; }
        public double TimeOfWork { get; set; }
    }
}