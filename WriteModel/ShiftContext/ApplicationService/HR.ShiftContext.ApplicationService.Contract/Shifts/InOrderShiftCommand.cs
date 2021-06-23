using Framework.Core.ApplicationService;
using System;

namespace HR.ShiftContext.ApplicationService.Contract.Shifts
{
    public class InOrderShiftCommand : Command
    {
        public Guid ShiftId { get; set; }
        public Guid NextShiftId { get; set; }
    }
}
