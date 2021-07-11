using System;
using Framework.Core.Domain;

namespace HR.EmployeeContext.Facade.Contract
{
    public interface IShiftAssignmentShiftIdValidateAclService:IACLService
    {
        bool IsExistShiftId(Guid shiftId);
    }
}
