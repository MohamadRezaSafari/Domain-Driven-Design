using System;
using System.Linq;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.Domain.Services.Shift
{
    public class InOrderDuplicationChecker : IInOrderDuplicationChecker
    {
        private readonly IShiftRepository shiftRepository;

        public InOrderDuplicationChecker(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public bool isDuplicate(Guid shiftId, Guid nextShiftId)
        {
            return shiftRepository.Any(sh => sh.Id == shiftId && sh.ShiftSegments.Select(a => a.NextShiftId).Contains(nextShiftId));
        }
    }
}