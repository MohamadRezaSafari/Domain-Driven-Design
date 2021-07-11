using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.ShiftContext.ApplicationService.Contract.Shifts
{
    public class ShiftSegmentCreateCommand : Command
    {
        public Guid ShiftId { get; set; }
        public TimeSpan StartTime { get; set; }
        public double AttendanceTime { get; set; }
    }
}
