using System;
using Framework.Domain;
using HR.EmployeeContext.Domain.Employees.Exceptions.EmployeeContract;
using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Employees
{
    public class EmployeeContract : EntityBase
    {
        public EmployeeContract()
        {
            
        }

        public EmployeeContract(IEmployeeRepository employeeRepository,long employeeId, DateTime endDate,Guid unitId)
        {
            
            SetStartDate(employeeRepository,employeeId,endDate);
            SetEndDate(endDate);
            SetUnitId(unitId);
        }


        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; set; }
        public Guid UnitId { get; private set; }

        private void SetStartDate(IEmployeeRepository employeeRepository,long employeeId,DateTime endDate)
        {
            var shiftAssignedStartDate =employeeRepository.GetLastShiftAssignmentByEmployeeId(employeeId).StartDate;
            
            if(shiftAssignedStartDate.Equals(default) ||(shiftAssignedStartDate.Equals(null)))
                throw new EmptyEmployeeContractStartTimeException();
            if(shiftAssignedStartDate > endDate)
                throw new StartTimeShouldBeLessThanException();

            StartDate = shiftAssignedStartDate;
        }
        private void SetEndDate(DateTime endDate)
        {
            if (endDate.Equals(default) || (endDate.Equals(null)))
                throw new EmptyEmployeeContractEndTimeException();
            EndDate = endDate;
        }
        private void SetUnitId(Guid unitId)
        {
            if (UnitId.Equals(null))
                throw new EmptyEmployeeContractUnitIdException();
            UnitId = unitId;
        }




    }
}
