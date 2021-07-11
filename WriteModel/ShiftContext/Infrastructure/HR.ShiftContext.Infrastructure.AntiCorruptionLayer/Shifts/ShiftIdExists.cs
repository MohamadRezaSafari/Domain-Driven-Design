using System;
using HR.EmployeeContext.Domain.Employees.Services.ACL;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.EmployeeContext.Infrastructure.AntiCorruptionLayer.Shifts
{
    public class ShiftIdExists : IShiftIdExists
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftIdExists(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public bool IsExistShiftId(Guid shiftsegmentId)
        {
            if (shiftRepository.IsShiftSegmentExist(shiftsegmentId))
                return true;

            return false;
        }
    }
}
