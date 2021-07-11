using System;
using System.Collections.Generic;
using System.Linq;
using HR.EmployeeContext.Domain.Employees.Services.ACL;
using HR.EmployeeContext.Domain.Employees.Services.ACL.Dto;
using HR.ShiftContext.Domain.Shifts.Services;
using Mapster;

namespace HR.EmployeeContext.Infrastructure.AntiCorruptionLayer.Shifts
{
    public class ShiftRepositoryACL : IShiftRepositoryACL
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftRepositoryACL(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }


        public List<ShiftSegmentDto> GetShiftSegments(Guid shiftId)
        {
            return shiftRepository.GetShiftSegments(shiftId).Adapt<List<ShiftSegmentDto>>();
        }


        public ShiftDto GetShiftByShiftSegmentId(Guid shiftSegmentId)
        {
            return shiftRepository.GetShiftByShiftSegmentId(shiftSegmentId).Adapt<ShiftDto>();
        }


    }
}
