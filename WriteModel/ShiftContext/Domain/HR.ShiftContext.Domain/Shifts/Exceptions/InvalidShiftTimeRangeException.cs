using Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.Shifts.Exceptions
{
    public class InvalidShiftTimeRangeException : DomainException
    {
        public override string Message => ExceptionResource.InvalidShiftTimeRangeException;
    }
}
