using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class Shift
    {
        public Shift()
        {
            ShiftSegments = new HashSet<ShiftSegment>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<ShiftSegment> ShiftSegments { get; set; }
    }
}
