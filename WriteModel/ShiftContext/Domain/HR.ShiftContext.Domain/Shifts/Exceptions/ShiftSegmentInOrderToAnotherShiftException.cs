﻿using Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.Shifts.Exceptions
{
    public class ShiftSegmentInOrderToAnotherShiftException : DomainException
    {
        public override string Message => ExceptionResource.ShiftSegmentInOrderToAnotherShiftException;
    }
}
