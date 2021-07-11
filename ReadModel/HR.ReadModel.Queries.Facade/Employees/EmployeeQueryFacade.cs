using System.Collections.Generic;
using System.Linq;
using Framework.Facade;
using HR.ReadModel.Context.Models;
using HR.ReadModel.Queries.Contracts.Employees;

namespace HR.ReadModel.Queries.Facade.Employees
{
    public class EmployeeQueryFacade: FacadeQueryBase, IEmployeeQueryFacade
    {
        private readonly HR_DeveloperContext context;

        public EmployeeQueryFacade(HR_DeveloperContext context)
        {
            this.context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return context.Employees.ToList();
        }

        public List<EmployeeIo> GetEmployeeIos()
        {
            return context.EmployeeIos.ToList();
        }
    }
}