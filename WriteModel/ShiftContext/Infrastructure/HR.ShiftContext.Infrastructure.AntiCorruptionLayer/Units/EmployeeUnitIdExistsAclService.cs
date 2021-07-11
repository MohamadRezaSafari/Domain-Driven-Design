using System;
using HR.DefinitionContext.Domain.Units.Services;
using HR.EmployeeContext.Domain.Employees.Services.ACL;

namespace HR.EmployeeContext.Infrastructure.AntiCorruptionLayer.Units
{
    public class EmployeeUnitIdExistsAclService: IEmployeeUnitIdExistsAclService
    {
        private readonly IUnitRepository _unitRepository;

        public EmployeeUnitIdExistsAclService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }


        public bool IsExistUnitId(Guid unitId)
        {
            return _unitRepository.Any(u => u.Id == unitId);
        }
    }
}