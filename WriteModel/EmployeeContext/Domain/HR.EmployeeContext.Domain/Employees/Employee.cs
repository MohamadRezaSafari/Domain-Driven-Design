using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Domain;
using Framework.Domain;
using HR.EmployeeContext.Domain.Employees.Dto;
using HR.EmployeeContext.Domain.Employees.Exceptions.Employee;
using HR.EmployeeContext.Domain.Employees.Exceptions.performance;
using HR.EmployeeContext.Domain.Employees.Exceptions.ShiftAssignment;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.EmployeeContext.Domain.Employees.Services.ACL;
using HR.EmployeeContext.Domain.Employees.Services.ACL.Dto;

namespace HR.EmployeeContext.Domain.Employees
{

    public class Employee : EntityBase, IAggregateRoot
    {

        protected Employee() { }

        public Employee(IEmployeeRepository employeeRepository, string firstName, string lastName)
        {

            SetFirstName(firstName);
            SetLastName(lastName);
        }

        public void UpdateEmployee(IEmployeeIsExists employeeIsExists, IEmployeeHasShift employeeHasShift, string firstName, string lastName)
        {
            if (!employeeIsExists.IsExists(this.EmployeeId))
                throw new EmployeeIsExistsException();

            if (!string.IsNullOrWhiteSpace(firstName))
                SetFirstName(firstName);

            if (!string.IsNullOrWhiteSpace(lastName))
                SetLastName(lastName);
        }

        public void DeleteEmployee(IEmployeeIsExists employeeIsExists)
        {
            if (!employeeIsExists.IsExists(this.EmployeeId))
                throw new EmployeeIsExistsException();

            IsActive = false;
        }


        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new FirstNameRequiredException();

            FirstName = firstName;
        }


        private void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new LastNameRequiredException();

            LastName = lastName;
        }


        public long EmployeeId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsActive { get; set; }
        public DateTime? SettlementDate { get; private set; }
        public Guid? UnitId { get; private set; }

        public ICollection<ShiftAssignment> ShiftAssignments { set; get; } = new HashSet<ShiftAssignment>();
        public ICollection<EmployeeIo> EmployeeIos { set; get; } = new HashSet<EmployeeIo>();

        public ICollection<EmployeeContract> EmployeeContracts { set; get; } = new HashSet<EmployeeContract>();

        public ICollection<Performance> Performance { set; get; } = new HashSet<Performance>();

        public void EmployeeReHire(IEmployeeIsExists employeeIsExists)
        {
            if (!employeeIsExists.IsExists(EmployeeId))
                throw new EmployeeIsExistsException();

            IsActive = true;
        }

        public void AddEmployeeUnitId(IEmployeeUnitIdExistsAclService employeeUnitIdValidateAclService, Guid unitId)
        {
            if (employeeUnitIdValidateAclService.IsExistUnitId(unitId))
                throw new UnitIdNotExistsException();

            UnitId = unitId;
        }



        public void EmployeeSettlement(DateTime settlementDate)
        {
            var employeeLastContract = EmployeeContracts.OrderByDescending(i => i.StartDate).FirstOrDefault();
            if (employeeLastContract != null)
            {
                if (settlementDate > employeeLastContract.EndDate)
                    throw new InvalidEmployeeSettlementDateException();

                employeeLastContract.EndDate = settlementDate;
            }

            var employeeLastShiftAssign = ShiftAssignments.OrderByDescending(i => i.StartDate).FirstOrDefault();
            if (employeeLastShiftAssign != null)
                employeeLastShiftAssign.EndDate = settlementDate;

            SettlementDate = settlementDate;
            IsActive = false;
        }


        public void AddEmployeeIo(EmployeeIo employeeIo, ShiftAssignment shiftAssignment, EmployeeContract employeeContract, ShiftDto shift, List<ShiftSegmentDto> shiftSegmentDto)
        {
            var daysSpentFromLastEmployeeContact = (DateTime.Now.Date - employeeContract.StartDate.Date).Days;
            var dayOfShiftSegment = daysSpentFromLastEmployeeContact % (shift.ShiftSegments.Count);
            var calculateLoopCounter = (dayOfShiftSegment == 0) ? shift.ShiftSegments.Count : dayOfShiftSegment;

            Guid? nextSegmentId = null;
            for (int c = 1; c <= calculateLoopCounter; c++)
            {
                if (c == 1)
                    nextSegmentId = shiftSegmentDto.Where(i => shiftAssignment.ShiftSegmentId == i.Id).First().NextShiftId;
                else
                {
                    if (calculateLoopCounter > 1)
                        nextSegmentId = shiftSegmentDto.Where(i => nextSegmentId == i.Id).First().NextShiftId;
                }
            }

            var finalSegment = shiftSegmentDto.Where(i => i.Id == nextSegmentId).Select(i => new { i.StartTime, i.EndTime }).ToList()[0];
            this.TimeValidationChecker(employeeIo, finalSegment.StartTime, finalSegment.EndTime);
            EmployeeIos.Add(employeeIo);
        }

        private void TimeValidationChecker(EmployeeIo employeeIo, TimeSpan start, TimeSpan end)
        {
            if (start == end)
                throw new HolidayException();

            if (start > end)
            {
                if ((employeeIo.DateTime.TimeOfDay <= start) || (employeeIo.DateTime.TimeOfDay >= end))
                    throw new InvalidEmployeeIO();
            }
            else
            {
                if ((employeeIo.DateTime.TimeOfDay <= start) || (employeeIo.DateTime.TimeOfDay >= end))
                    throw new InvalidEmployeeIO();
            }
        }

        public void AssignShift(IShiftIdExists shiftIdExists, ShiftAssignment shiftAssignment, Guid shiftId)
        {
            if (!shiftIdExists.IsExistShiftId(shiftId))
                throw new ShiftIdNotExistsException();

            ShiftAssignments.Add(shiftAssignment);
        }

        public IEnumerable<Expression<Func<Employee, object>>> GetAggregateExpression()
        {
            yield return e => e.ShiftAssignments;
            yield return e => e.EmployeeContracts;
        }

        public void ConcludeEmployeeContract(IEmployeeRepository employeeRepository, long employeeId, EmployeeContract employeeContract)
        {
            var lastAssigned = employeeRepository.GetLastShiftAssignmentByEmployeeId(employeeId);
            if (lastAssigned == null)
                throw new EmptyShiftAssignedException();
            EmployeeContracts.Add(employeeContract);
        }


        public List<EmployeePerformanceSegmentDto> CalculatePerformance(IEmployeeHasEmployeeContract employeeHasEmployeeContract, IShiftRepositoryACL shiftRepositoryAcl, DateTime fromDate, DateTime toDate)
        {
            if (!employeeHasEmployeeContract.HaveEmployeeEmployeeContract(Id))
                throw new EmployeeDontHaveEmployeeContractException();

            List<ShiftAssignmentDto> shiftAssignments = new List<ShiftAssignmentDto>();
            List<EmployeePerformanceDto> employeePerformanceDtos = new List<EmployeePerformanceDto>();

            var employeeShiftAssignments = GetEmployeeAssignments(Id, fromDate, toDate);

            var shiftSegmentIds = employeeShiftAssignments
                .Select(i => i.ShiftSegmentId)
                .ToList();

            var a = shiftRepositoryAcl.GetAllShifts();

            var shiftSegmentIdList = shiftRepositoryAcl.GetAllShifts()
                .Where(i => i.ShiftSegments.Any(a => shiftSegmentIds.Contains(a.Id)))
                .SelectMany(i => i.ShiftSegments)
                .ToList();

            var shifts = shiftRepositoryAcl.GetAllShifts()
                .Where(i => i.ShiftSegments.Any(x => shiftSegmentIdList.Select(a => a.ShiftId).Distinct().Contains(x.ShiftId)))
                .ToList();

            var employeeSortedIo = GetEmployeeSortedIo(Id);

            foreach (var item in employeeShiftAssignments.Where(i => shiftSegmentIdList.Select(x => x.Id).ToList().Contains(i.ShiftSegmentId.Value)).ToList())
            {
                shiftAssignments.Add(item.EndDate != null
                    ? new ShiftAssignmentDto()
                    {
                        Id = item.Id,
                        ShiftSegmentId = item.ShiftSegmentId.Value,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate.Value
                    }
                    : new ShiftAssignmentDto()
                    {
                        Id = item.Id,
                        ShiftSegmentId = item.ShiftSegmentId.Value,
                        StartDate = item.StartDate,
                        EndDate = toDate
                    });
            }

            foreach (var shiftAssign in shiftAssignments)
            {
                var shiftSegmentStart = shiftAssign.ShiftSegmentId;
                Guid nextSegmentId = shiftSegmentStart;

                foreach (var io in employeeSortedIo)
                {
                    if (io.Key >= shiftAssign.StartDate && io.Key <= shiftAssign.EndDate)
                    {
                        var currentShiftSegment = shiftSegmentIdList.Find(i => i.Id == nextSegmentId);

                        if (currentShiftSegment.EndTime.TotalSeconds == 0 && currentShiftSegment.StartTime.TotalSeconds == 0)
                        {
                            nextSegmentId = currentShiftSegment.NextShiftId.Value;
                            continue;
                        }

                        employeePerformanceDtos.Add(new EmployeePerformanceDto()
                        {
                            EmployeeId = this.Id,
                            ShiftSegmentId = nextSegmentId,
                            TimeOfWork = io.Value.TotalSeconds
                        });

                        nextSegmentId = currentShiftSegment.NextShiftId.Value;
                    }
                }
            }

            return employeePerformanceDtos
                .GroupBy(ep => new { ep.ShiftSegmentId })
                .Select(ep => new EmployeePerformanceSegmentDto()
                {
                    ShiftSegmentId = ep.Key.ShiftSegmentId,
                    ShiftId = shifts.Where(sh => sh.ShiftSegments.Any(shiftSegment => shiftSegment.Id == ep.Key.ShiftSegmentId)).First().Id,
                    SumOfWorkHoure = TimeSpan.FromSeconds(ep.Sum(a => a.TimeOfWork))
                })
                .ToList();
        }



        public void AddPerformance(IEmployeeHasShiftAssignment employeeHasShiftAssignment, IPerformanceDuplicateChecker performanceDuplicateChecker,Performance performance)
        {
            if (!employeeHasShiftAssignment.HasEmployeeShiftAssign(EmployeeId))
                throw new EmployeeDontHaveShiftAssignmentException();

            if (performanceDuplicateChecker.IsDuplicated(this.Id, performance.FromDate.Date, performance.ToDate.Date))
                throw new EmployeeDontHaveShiftAssignmentException();

            this.Performance.Add(performance);
        }

        private List<ShiftAssignment> GetEmployeeAssignments(Guid employeeId, DateTime fromDate, DateTime toDate)
        {
            return this.ShiftAssignments
                .Where(sa => ((sa.StartDate <= fromDate &&
                                  (sa.EndDate != null && sa.EndDate >= toDate))
                                 || (sa.StartDate > fromDate
                                     && (sa.StartDate < toDate ||
                                         (sa.EndDate != null && sa.EndDate <= toDate))
                                 )
                             )
                ).OrderBy(assignment => assignment.StartDate)
                .ToList();
        }

        private SortedList<DateTime, TimeSpan> GetEmployeeSortedIo(Guid employeeId)
        {
            var ios = new SortedList<DateTime, TimeSpan>();
            var employeeIOs = this.EmployeeIos.Where(io => io.EmployeeId == employeeId).OrderBy(io => io.DateTime).ToList();
            for (int i = 2; i <= employeeIOs.Count; i += 2)
            {
                var totalSeconds = employeeIOs[i - 1].DateTime.TimeOfDay.TotalSeconds - employeeIOs[i - 2].DateTime.TimeOfDay.TotalSeconds;
                ios.Add(employeeIOs[i - 2].DateTime, TimeSpan.FromSeconds(Math.Abs(totalSeconds)));
            }
            return ios;
        }


    }
}
