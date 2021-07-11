using Framework.Core.Persistence;
using HR.ShiftContext.Domain.ShiftTemplates;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HR.ShiftContext.Domain.Shifts.Services
{
    public interface IShiftRepository : IRepository
    {
        List<ShiftSegment> GetShiftSegments(Guid shiftId);
        Shift GetShiftByShiftSegmentId(Guid shiftSegmentId);
        List<Shift> GetShifts(List<Guid> shiftIds);
        void ShiftCreate(Shift shift);
        bool Any(Expression<Func<Shift, bool>> expression);
        Shift GetShiftById(Guid shiftId);
        bool IsShiftSegmentExist(Guid ShiftSegmentId);
    }
}
