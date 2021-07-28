using Framework.Core.Facade;
using HR.EmployeeContext.ApplicationService.Contract.Employees;

namespace HR.EmployeeContext.Facade.Contract
{
    public interface IEmployeeCommandFacade
    {
        void EmployeeReHire(EmployeeReHireCommand command);
        void EmployeeSettlement(EmployeeSettlementCommand command);
        void CreateEmployee(EmployeeCreateCommand command);
        void DeleteEmployee(EmployeeDeleteCommand command);
        void UpdateEmployee(EmployeeUpdateCommand command);
        void AssignShift(ShiftAssignmentCommend command);
        void ConcludeEmployeeContract(EmployeeContractCreateCommand command);
        void CreateEmployeeIO(EmployeeIOCreateCommand command);
        void CalculateEmployeePerformance(EmployeePerformanceCalculateCommand command);
    }
}