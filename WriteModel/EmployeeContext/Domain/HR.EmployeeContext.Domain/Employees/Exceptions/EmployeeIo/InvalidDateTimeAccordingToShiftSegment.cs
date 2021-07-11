using Framework.Domain;
using HR.EmployeeContext.Resources;


namespace HR.EmployeeContext.Domain.Employees.Exceptions.EmployeeIo
{
    public class InvalidDateTimeAccordingToShiftSegment : DomainException
    {
        public override string Message => ExceptionResource.InvalidDateTimeAccordingToShiftSegmentException;
    }
}
