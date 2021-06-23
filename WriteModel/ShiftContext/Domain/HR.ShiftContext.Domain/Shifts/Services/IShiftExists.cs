using Framework.Core.Domain;
using System;

namespace HR.ShiftContext.Domain.Shifts.Services
{
    public interface IShiftExists : IDomainService
    {
        bool Exist(Guid shiftId);
    }
}