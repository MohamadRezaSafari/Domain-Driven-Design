using Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.Shifts.Exceptions
{
    public class ShiftIdRequiredException : DomainException
    {
        public override string Message => ExceptionResource.ShiftIdRequiredException;
    }
}
