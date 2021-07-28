using System;

namespace HR.EmployeeContext.Domain.Employees.Dto
{
    public class EmployeePerformanceSegmentDto
    {
        public Guid ShiftId { get; set; }
        public Guid ShiftSegmentId { get; set; }
        public TimeSpan SumOfWorkHoure { get; set; }
    }
}
