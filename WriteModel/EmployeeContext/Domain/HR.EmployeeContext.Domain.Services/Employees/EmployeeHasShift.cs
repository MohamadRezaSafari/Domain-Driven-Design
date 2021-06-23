using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Services.Employees
{
    public class EmployeeHasShift:IEmployeeHasShift
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeHasShift(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        //public bool HasShift(long EmployeeId)
        //{
        // //   return _employeeRepository.BoolHasShift(e => e.EmployeeId == EmployeeId );
        //}
    }
}
