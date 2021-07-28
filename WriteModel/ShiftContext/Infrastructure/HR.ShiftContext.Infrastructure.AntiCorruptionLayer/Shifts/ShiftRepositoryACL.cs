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

        public List<ShiftSegmentDto> GetShiftByShiftSegmentId(List<Guid> ids)
        {
            var shiftSegmentIdList = shiftRepository.GetAllShifts()
                .Where(i => i.ShiftSegments.Any(a => ids.Contains(a.Id)))
                .SelectMany(i => i.ShiftSegments)
                .ToList();

            return shiftSegmentIdList.Adapt<List<ShiftSegmentDto>>();
            //var shiftSegmentIdList = shiftRepository.Shifts
            //    .Where(i => i.ShiftSegments.Any(a => shiftSegmentIds.Contains(a.Id)))
            //    .SelectMany(i => i.ShiftSegments)
            //    .ToList();
        }

        public List<ShiftDto> GetAllShifts()
        {
            return shiftRepository.GetAllShifts().Adapt<List<ShiftDto>>();
        }
    }
}
