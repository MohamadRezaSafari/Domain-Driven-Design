using System;
using Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services.ACL
{
    public interface IEmployeeUnitIdExistsAclService : IACLService
    {
        bool IsExistUnitId(Guid unitId);
    }
}