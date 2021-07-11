using Framework.Domain;
using HR.ShiftContext.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.ShiftContext.Domain.Shifts.Exceptions
{
    class NextShiftSegmentStartTimeGreaterThanShiftSegmentEndTimeException : DomainException
    {
        public override string Message => ExceptionResource.NextShiftSegmentStartTimeGreaterThanShiftSegmentEndTimeException;
    }
}
