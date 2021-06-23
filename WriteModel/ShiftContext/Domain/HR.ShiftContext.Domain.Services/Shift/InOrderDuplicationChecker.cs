using System;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.Domain.Services.Shift
{
    public class InOrderDuplicationChecker: IInOrderDuplicationChecker
    {
        private readonly IShiftRepository _shiftRepository;

        public InOrderDuplicationChecker(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }
        public bool isDuplicate(Guid shiftTemplateIdGuid, long nextShiftId)
        {
            return true;
            //return _shiftRepository.Any(sh => sh.ShiftTemplateId == shiftTemplateIdGuid && sh.NextShift == nextShiftId);
        }
    }
}