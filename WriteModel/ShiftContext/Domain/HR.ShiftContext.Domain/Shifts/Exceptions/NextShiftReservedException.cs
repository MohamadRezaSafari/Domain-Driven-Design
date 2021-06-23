using Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.Shifts.Exceptions
{
    public class NextShiftReservedException : DomainException
    {
        public override string Message => ExceptionResource.NextShiftReservedException;
    }
}
