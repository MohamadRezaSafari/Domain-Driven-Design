using System.Collections.Generic;
using HR.ReadModel.Context.Models;

namespace HR.ReadModel.Queries.Contracts.Employees
{
    public interface IEmployeeQueryFacade
    {
        List<Employee> GetAllEmployees();
    }
}