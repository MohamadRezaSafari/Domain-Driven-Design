using System;

namespace HR.ReadModel.Queries.Contracts.Employees.DataContracts.Employees.EmployeePerformance
{
    public class EmployeePerformanceSegmentDto
    {
        public Guid ShiftId { get; set; }
        public Guid ShiftSegmentId { get; set; }
        public long SumOfWorkHoure { get; set; }
    }
}
