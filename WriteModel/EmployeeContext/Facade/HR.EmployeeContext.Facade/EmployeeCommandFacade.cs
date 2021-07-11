using Framework.Core.ApplicationService;
using Framework.Facade;
using HR.EmployeeContext.ApplicationService.Contract.Employees;
using HR.EmployeeContext.Facade.Contract;

namespace HR.EmployeeContext.Facade
{
    public class EmployeeCommandFacade : FacadeCommandBase, IEmployeeCommandFacade
    {

        public EmployeeCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }

        public void EmployeeReHire(EmployeeReHireCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void EmployeeSettlement(EmployeeSettlementCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void CreateEmployee(EmployeeCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteEmployee(EmployeeDeleteCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateEmployee(EmployeeUpdateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void AssignShift(ShiftAssignmentCommend command)
        {
            CommandBus.Dispatch(command);
        }


        public void ConcludeEmployeeContract(EmployeeContractCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void CreateEmployeeIO(EmployeeIOCreateCommand command)
        {
            //command.IsValid = employeeIoDateTimeValidateAclService.IsValidDateTime(command.EmployeeId, DateTime.Now);
            CommandBus.Dispatch(command);
        }

    }
}