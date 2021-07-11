using System;
using Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services.ACL
{
    public interface IShiftAssignmentShiftIdExistAclService : IACLService
    {
        bool IsExistShiftId(Guid shiftId);
    }
}
