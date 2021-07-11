using Framework.Core.Domain;
using Framework.Domain;
using HR.ShiftContext.Domain.Shifts.Exceptions;
using System;
using HR.ShiftContext.Domain.Shifts.Services;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace HR.ShiftContext.Domain.Shifts
{
    public class Shift : EntityBase, IAggregateRoot
    {
        protected Shift() { }

        public Shift(string title)
        {
            SetTitle(title);
        }


        public void AddShiftSegment(ShiftSegment shiftSegment)
        {
            this.ShiftSegments.Add(shiftSegment);
        }


        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ShiftTitleRequiredException();

            Title = title;
        }


        public void SetInOrderNextShiftSegmentId(IInOrderDuplicationChecker inOrderDuplicationChecker, Guid shiftSegmentId, Shift nextShiftSegment, Guid nextShiftSegmentId)
        {
            if (this.ShiftSegments.Count() <= 1)
                throw new InvalidInOrderSingleShiftSegmentException();

            if (this.Id == nextShiftSegmentId)
                throw new NextShiftRecursiveException();

            if (!this.ShiftSegments.Any(i => i.Id == nextShiftSegmentId))
                throw new ShiftSegmentInOrderToAnotherShiftException();

            if (this.ShiftSegments.First(i => i.Id == shiftSegmentId).Id == nextShiftSegmentId)
                throw new ShiftSegmentInOrderInvalidSelfRefrenceException();

            if (inOrderDuplicationChecker.isDuplicate(this.Id, nextShiftSegmentId))
                throw new NextShiftReservedException();

            var currentShiftSegmentEndTime = this.ShiftSegments.First(i => i.Id == shiftSegmentId).EndTime;
            var nextShiftSegmentStartTime = nextShiftSegment.ShiftSegments.First(i => i.Id == nextShiftSegmentId).StartTime;

            if (
                (currentShiftSegmentEndTime.TotalSeconds != 0 && nextShiftSegmentStartTime.TotalSeconds != 0)
                &&
                (currentShiftSegmentEndTime > nextShiftSegmentStartTime)
            )
                throw new NextShiftSegmentStartTimeGreaterThanShiftSegmentEndTimeException();

            this.ShiftSegments.First(i => i.Id == shiftSegmentId).NextShiftId = nextShiftSegmentId;
        }



        public string Title { get; set; }
        public ICollection<ShiftSegment> ShiftSegments { get; private set; } = new HashSet<ShiftSegment>();


        public IEnumerable<Expression<Func<Shift, object>>> GetAggregateExpression()
        {
            yield return i => i.ShiftSegments;
        }
    }
}
