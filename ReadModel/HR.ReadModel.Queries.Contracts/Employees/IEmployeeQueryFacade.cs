using System;
using System.Collections.Generic;
using HR.ReadModel.Context.Models;
using HR.ReadModel.Queries.Contracts.Employees.DataContracts;
using HR.ReadModel.Queries.Contracts.Employees.DataContracts.Employees.EmployeePerformance;

namespace HR.ReadModel.Queries.Contracts.Employees
{
    public interface IEmployeeQueryFacade
    {
        List<Employee> GetAllEmployees();
        List<EmployeeIo> GetEmployeeIos();
        List<EmployeePerformanceSegmentDto> CalculatePerformance(Guid employeeId, DateTime fromDate, DateTime toDate);
    }
}