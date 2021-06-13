using Framework.Core.Persistence;
using HR.ShiftContext.Domain.ShiftTemplates;
using System;
using System.Collections.Generic;

namespace HR.ShiftContext.Domain.Shifts.Services
{
    public interface IShiftRepository : IRepository
    {
        void ShiftCreate(Shift shift);
        void ShiftTermplateCreate(ShiftTemplate shiftTemplate);
        List<ShiftTemplate> ShiftTemplateExist(Guid shiftTemplateId);
    }
}
