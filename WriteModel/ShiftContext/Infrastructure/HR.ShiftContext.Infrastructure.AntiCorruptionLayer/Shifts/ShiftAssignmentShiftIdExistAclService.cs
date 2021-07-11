using System;
using HR.EmployeeContext.Facade.Contract;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.EmployeeContext.Infrastructure.AntiCorruptionLayer.Shifts
{
    public class ShiftAssignmentShiftIdValidateAclService : IShiftAssignmentShiftIdValidateAclService
    {
        //private readonly IShiftRepository shiftRepository;

        //public ShiftAssignmentShiftIdValidateAclService(IShiftRepository shiftRepository)
        //{
        //    this.shiftRepository = shiftRepository;
        //}
        //public bool IsExistShiftId(Guid shiftId)
        //{
        //    if (shiftRepository.GetShiftByShiftSegmentId(shiftId) != null)
        //        return true;
        //    return false;
        //}
        public bool IsExistShiftId(Guid shiftId)
        {
            return true;
        }
    }
}
