using System;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Services.Employees
{
    public class EmployeeHasEmployeeContract: IEmployeeHasEmployeeContract
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeHasEmployeeContract(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool HaveEmployeeEmployeeContract(Guid employeeId)
        {
            //_employeeRepository.HasEmployeeContract(employeeId);
            return true;
        }
    }
}