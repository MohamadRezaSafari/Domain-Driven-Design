using System;
using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Dto
{
    public class ShiftAssignmentDto : EntityBase
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ShiftSegmentId { get; set; }
    }
}
