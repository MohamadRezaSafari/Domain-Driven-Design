using System;
using System.Linq;
using Framework.Core.ApplicationService;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.EmployeeContext.Domain.Employees.Services.ACL;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeePerformanceCalculateCommandHandler : ICommandHandler<EmployeePerformanceCalculateCommand>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeHasEmployeeContract employeeHasEmployeeContract;
        private readonly IShiftRepositoryACL shiftRepositoryAcl;
        private readonly IEmployeeHasShiftAssignment employeeHasShiftAssignment;
        private readonly IPerformanceDuplicateChecker performanceDuplicateChecker;

        public EmployeePerformanceCalculateCommandHandler(IEmployeeRepository employeeRepository, IEmployeeHasEmployeeContract employeeHasEmployeeContract,
             IShiftRepositoryACL shiftRepositoryAcl, IEmployeeHasShiftAssignment employeeHasShiftAssignment, IPerformanceDuplicateChecker performanceDuplicateChecker)
        {
            this.employeeRepository = employeeRepository;
            this.employeeHasEmployeeContract = employeeHasEmployeeContract;
            this.shiftRepositoryAcl = shiftRepositoryAcl;
            this.employeeHasShiftAssignment = employeeHasShiftAssignment;
            this.performanceDuplicateChecker = performanceDuplicateChecker;
        }

        public void Execute(EmployeePerformanceCalculateCommand command)
        {
            var employee = employeeRepository.GetByEmployeeId(command.EmployeeId);
            var calculatedPerformance = employee.CalculatePerformance(employeeHasEmployeeContract, shiftRepositoryAcl, command.FromDate, command.ToDate);

            Performance performance = new Performance(command.FromDate, command.ToDate, 0, employee.Id);

            foreach (var item in calculatedPerformance)
                performance.Details.Add(new PerformanceDetail(performance.Id, item.ShiftSegmentId, TimeSpan.FromSeconds(item.SumOfWorkHoure.TotalSeconds).Hours));
            
            performance.Sum = performance.Details.Select(i => i.Sum).ToList().Sum(i => i);
            employee.AddPerformance(employeeHasShiftAssignment, performanceDuplicateChecker, performance);
        }
    }
}