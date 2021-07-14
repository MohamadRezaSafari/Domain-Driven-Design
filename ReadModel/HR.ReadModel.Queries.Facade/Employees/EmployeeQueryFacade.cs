using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Facade;
using HR.ReadModel.Context.Models;
using HR.ReadModel.Queries.Contracts.Employees;
using HR.ReadModel.Queries.Contracts.Employees.DataContracts.Employees.EmployeePerformance;

namespace HR.ReadModel.Queries.Facade.Employees
{
    public class EmployeeQueryFacade : FacadeQueryBase, IEmployeeQueryFacade
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

        private List<ShiftAssignment> GetEmployeeAssignments(Guid employeeId, DateTime fromDate, DateTime toDate)
        {
            return context.ShiftAssignments
                .Where(sa => sa.EmployeeId == employeeId
                             && ((sa.StartDate <= fromDate &&
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
            var employeeIOs = context.EmployeeIos.Where(io => io.EmployeeId == employeeId).OrderBy(io => io.DateTime).ToList();
            for (int i = 2; i <= employeeIOs.Count; i += 2)
            {
                var totalSeconds = employeeIOs[i - 1].DateTime.TimeOfDay.TotalSeconds - employeeIOs[i - 2].DateTime.TimeOfDay.TotalSeconds;
                ios.Add(employeeIOs[i - 2].DateTime, TimeSpan.FromSeconds(Math.Abs(totalSeconds)));
            }
            return ios;
        }

        public List<EmployeePerformanceSegmentDto> CalculatePerformance(Guid employeeId, DateTime fromDate, DateTime toDate)
        {
            List<ShiftAssignment> shiftAssignments = new List<ShiftAssignment>();
            List<EmployeePerformanceDto> employeePerformanceDtos = new List<EmployeePerformanceDto>();

            var employeeShiftAssignments = GetEmployeeAssignments(employeeId, fromDate, toDate);

            var shiftSegmentIds = employeeShiftAssignments
                .Select(i => i.ShiftSegmentId)
                .ToList();

            var shiftSegmentIdList = context.Shifts
                .Where(i => i.ShiftSegments.Any(a => shiftSegmentIds.Contains(a.Id)))
                .SelectMany(i => i.ShiftSegments)
                .ToList();

            var shifts = context.Shifts
                .Where(i => i.ShiftSegments.Any(x => shiftSegmentIdList.Select(a => a.ShiftId).Distinct().Contains(x.ShiftId)))
                .ToList();

            var employeeSortedIo = GetEmployeeSortedIo(employeeId);

            foreach (var item in employeeShiftAssignments.Where(i => shiftSegmentIdList.Select(x => x.Id).ToList().Contains(i.ShiftSegmentId)).ToList())
            {
                shiftAssignments.Add(item.EndDate != null
                    ? new ShiftAssignment()
                    {
                        Id = item.Id,
                        ShiftSegmentId = item.ShiftSegmentId,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate
                    }
                    : new ShiftAssignment()
                    {
                        Id = item.Id,
                        ShiftSegmentId = item.ShiftSegmentId,
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
                    if (io.Key >= shiftAssign.StartDate && io.Key <= shiftAssign.EndDate.Value)
                    {
                        var currentShiftSegment = shiftSegmentIdList.Find(i => i.Id == nextSegmentId);

                        if (currentShiftSegment.EndTime.TotalSeconds == 0 && currentShiftSegment.StartTime.TotalSeconds == 0)
                        {
                            nextSegmentId = currentShiftSegment.NextShiftId;
                            continue;
                        }

                        employeePerformanceDtos.Add(new EmployeePerformanceDto()
                        {
                            EmployeeId = employeeId,
                            ShiftSegmentId = nextSegmentId,
                            TimeOfWork = io.Value.TotalSeconds
                        });

                        nextSegmentId = currentShiftSegment.NextShiftId;
                    }
                }
            }


            return employeePerformanceDtos
                .GroupBy(ep => new { ep.ShiftSegmentId })
                .Select(ep => new EmployeePerformanceSegmentDto()
                {
                    ShiftSegmentId = ep.Key.ShiftSegmentId,
                    ShiftId = shifts.Where(sh => sh.ShiftSegments.Any(shiftSegment => shiftSegment.Id == ep.Key.ShiftSegmentId)).First().Id,
                    SumOfWorkHoure = TimeSpan.FromSeconds(ep.Sum(a => a.TimeOfWork)).Hours
                })
                .ToList();


        }
    }


}