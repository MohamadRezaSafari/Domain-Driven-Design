using Framework.Core.ApplicationService;
using System;

namespace HR.ShiftContext.ApplicationService.Contract.Shifts
{
    public class ShiftSegmentInOrderCommand : Command
    {
        public Guid ShiftId { get; set; }
        public Guid ShiftSegmentId { get; set; }
        public Guid NextShiftSegmentId { get; set; }
    }
}
