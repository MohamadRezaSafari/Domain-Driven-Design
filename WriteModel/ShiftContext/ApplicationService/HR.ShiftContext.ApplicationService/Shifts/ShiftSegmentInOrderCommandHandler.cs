using Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contract.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftSegmentInOrderCommandHandler : ICommandHandler<ShiftSegmentInOrderCommand>
    {
        private readonly IShiftRepository shiftRepository;
        private readonly IInOrderDuplicationChecker inOrderDuplicationChecker;

        public ShiftSegmentInOrderCommandHandler(IShiftRepository shiftRepository, IInOrderDuplicationChecker inOrderDuplicationChecker)
        {
            this.shiftRepository = shiftRepository;
            this.inOrderDuplicationChecker = inOrderDuplicationChecker;
        }

        public void Execute(ShiftSegmentInOrderCommand command)
        {
            var shift = shiftRepository.GetShiftById(command.ShiftId);
            var nextShiftSegment = shiftRepository.GetShiftByShiftSegmentId(command.NextShiftSegmentId);

            shift.SetInOrderNextShiftSegmentId( inOrderDuplicationChecker, 
                     command.ShiftSegmentId, nextShiftSegment, command.NextShiftSegmentId);
        }
    }
}