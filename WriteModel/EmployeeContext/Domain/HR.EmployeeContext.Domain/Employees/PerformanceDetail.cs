using System;
using Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees
{
    public class PerformanceDetail : EntityBase
    {
        public PerformanceDetail()
        {
        }

        public PerformanceDetail(Guid performanceId, Guid shiftSegmentId, long sum)
        {
            this.SetBaseId(performanceId);
            this.SetShiftSegmentId(shiftSegmentId);
            this.SetSum(sum);
        }


        public Guid PerformanceId { get; private set; }
        public Guid ShiftSegmentId { get; private set; }
        public long Sum { get; private set; }


        private void SetBaseId(Guid performanceId)
        {
            this.PerformanceId = performanceId;
        }

        private void SetShiftSegmentId(Guid shiftSegmentId)
        {
            this.ShiftSegmentId = shiftSegmentId;
        }

        private void SetSum(long sum)
        {
            this.Sum = sum;
        }
    }
}
