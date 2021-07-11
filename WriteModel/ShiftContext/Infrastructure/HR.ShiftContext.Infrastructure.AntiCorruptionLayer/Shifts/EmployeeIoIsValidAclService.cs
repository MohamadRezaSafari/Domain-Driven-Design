using System;
using System.Linq;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.EmployeeContext.Domain.Employees.Services.ACL;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.EmployeeContext.Infrastructure.AntiCorruptionLayer.Shifts
{
    public class EmployeeIoIsValidAclService: IEmployeeIoIsValidAclService
    {
        private readonly IShiftRepository shiftRepository;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeIoIsValidAclService(IShiftRepository shiftRepository,
            IEmployeeRepository employeeRepository)
        {
            this.shiftRepository = shiftRepository;
            this.employeeRepository = employeeRepository;
        }
        public bool IsValid(long employeeId, DateTime dateTime)
        {
            var lastAssignedShift = this.GetLastAssignedShift(employeeId);
            var lastAssignedShiftStartTime = lastAssignedShift.StartTime;
            var lastAssignedShiftEndTime = lastAssignedShift.EndTime;
            var validation = (dateTime.TimeOfDay < lastAssignedShiftStartTime) ||
                             (dateTime.TimeOfDay > lastAssignedShiftEndTime);
            if (validation)
                return false;
            return true;
        }
        public ShiftSegment GetLastAssignedShift(long employeeId)
        {
            var employee = employeeRepository.GetShiftAssignmentByEmployeeId(employeeId);
            var shiftSegmentId = employee.ShiftAssignments.OrderByDescending(e => e.StartDate).FirstOrDefault().ShiftSegmentId;
            return shiftRepository.GetShiftByShiftSegmentId(shiftSegmentId.Value).ShiftSegments.FirstOrDefault();
        }
    }
}
