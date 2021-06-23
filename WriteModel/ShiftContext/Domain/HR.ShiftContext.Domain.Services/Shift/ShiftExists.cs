using HR.ShiftContext.Domain.Shifts.Services;
using System;

namespace HR.ShiftContext.Domain.Services.Shift
{
    public class ShiftExists: IShiftExists
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftExists(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }
        public bool Exist(Guid shiftId)
        {
            return _shiftRepository.Any(e => e.Id == shiftId);
        }
    }
}