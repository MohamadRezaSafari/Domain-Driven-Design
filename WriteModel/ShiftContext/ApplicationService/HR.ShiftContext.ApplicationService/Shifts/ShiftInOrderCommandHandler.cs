using Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contract.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftInOrderCommandHandler : ICommandHandler<InOrderShiftCommand>
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IShiftExists _shiftExists;
        private readonly IInOrderDuplicationChecker _inOrderDuplicationChecker;

        public ShiftInOrderCommandHandler(IShiftRepository shiftRepository, IShiftExists shiftExists, IInOrderDuplicationChecker inOrderDuplicationChecker)
        {
            _shiftRepository = shiftRepository;
            _shiftExists = shiftExists;
            _inOrderDuplicationChecker = inOrderDuplicationChecker;
        }
        public void Execute(InOrderShiftCommand command)
        {
            var currentShift = _shiftRepository.GetShiftById(command.ShiftId);
            var nextShift = _shiftRepository.GetShiftById(command.NextShiftId);
            currentShift.SetInOrderNextShiftId(_shiftExists, _inOrderDuplicationChecker, nextShift);
        }
    }
}