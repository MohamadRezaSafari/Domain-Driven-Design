using Framework.Core.Persistence;
using HR.ShiftContext.Domain.ShiftTemplates;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HR.ShiftContext.Domain.Shifts.Services
{
    public interface IShiftRepository : IRepository
    {
        List<Shift> GetShifts(List<Guid> shiftIds);
        void ShiftCreate(Shift shift);
        void ShiftTermplateCreate(ShiftTemplate shiftTemplate);
        List<ShiftTemplate> ShiftTemplateExist(Guid shiftTemplateId);

        bool Any(Expression<Func<Shift, bool>> expression);
        Shift GetShiftById(Guid shiftId);
    }
}
