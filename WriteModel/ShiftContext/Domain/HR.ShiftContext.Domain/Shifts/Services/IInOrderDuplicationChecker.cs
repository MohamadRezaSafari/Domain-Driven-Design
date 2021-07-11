using System;
using Framework.Core.Domain;

namespace HR.ShiftContext.Domain.Shifts.Services
{
    public interface IInOrderDuplicationChecker : IDomainService
    {
        bool isDuplicate(Guid shiftTemplateIdGuid, Guid nextShiftId);
    }
}