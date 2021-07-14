using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class ShiftSegment
    {
        public Guid Id { get; set; }
        public Guid ShiftId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid NextShiftId { get; set; }

        public virtual Shift Shift { get; set; }
    }
}
