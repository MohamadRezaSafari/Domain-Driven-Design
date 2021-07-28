using System;
using Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IPerformanceDuplicateChecker : IDomainService
    {
        bool IsDuplicated(Guid employeeId, DateTime fromDate, DateTime toDate);
    }
}