using System;
using Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IEmployeeHasEmployeeContract: IDomainService
    {
        bool HaveEmployeeEmployeeContract(Guid employeeId);
    }
}
