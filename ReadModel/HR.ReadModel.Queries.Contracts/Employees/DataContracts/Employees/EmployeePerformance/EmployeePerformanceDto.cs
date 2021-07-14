using System;

namespace HR.ReadModel.Queries.Contracts.Employees.DataContracts.Employees.EmployeePerformance
{
    public class EmployeePerformanceDto
    {
        public Guid EmployeeId { get; set; }
        public Guid ShiftSegmentId { get; set; }
        public Guid ShiftId { get; set; }
        public double TimeOfWork { get; set; }

    }

    

    


}