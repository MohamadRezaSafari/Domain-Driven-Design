using Framework.Domain;
using HR.EmployeeContext.Resources;

namespace HR.EmployeeContext.Domain.Employees.Exceptions.EmployeeContract
{
    public class EmptyEmployeeContractEndTimeException : DomainException
    {
        public override string Message => ExceptionResource.EmptyEmployeeContractEndTimeException;
    }
}
