using Framework.Core.Domain;
using Framework.Domain;
using HR.ShiftContext.Domain.Shifts.Exceptions;
using HR.ShiftContext.Domain.ShiftTemplates.Exceptions;
using HR.ShiftContext.Domain.ShiftTemplates.Services;
using System;
using HR.ShiftContext.Domain.Shifts.Services;
using System.Collections.Generic;
using HR.ShiftContext.Domain.ShiftTemplates;
using System.Linq.Expressions;
using System.Linq;

namespace HR.ShiftContext.Domain.Shifts
{
    public class Shift : EntityBase, IAggregateRoot
    {
        private readonly IShiftTemplateExists shiftTemplateExists;

        protected Shift() { }

        public Shift(string title, TimeSpan startTime, TimeSpan endTime, Guid? nextShift, IShiftTemplateExists shiftTemplateExists)
        {
            this.shiftTemplateExists = shiftTemplateExists;

            SetTitle(title);
            //SetShiftTemplateId(shiftTemplateId, shiftTemplateExists);
            SetTime(startTime, endTime);
            NextShiftId = nextShift;
        }

        private void SetTime(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime == null && endTime == null)
                throw new ShiftTimeRequiredException();

            if (startTime > endTime)
                throw new InvalidShiftTimeRangeException();

            StartTime = startTime;
            EndTime = endTime;
        }

        private void SetShiftTemplateId(Guid shiftTemplateId, IShiftTemplateExists shiftTemplateExists)
        {
            if (shiftTemplateId == null)
                throw new ShiftTemplateIdRequiredException();

            if (!shiftTemplateExists.Exist(shiftTemplateId))
                throw new ShiftTemplateExistsException();

            ShiftTemplateId = shiftTemplateId;
        }

        private void SetTitle(string title)
        {
            if (String.IsNullOrWhiteSpace(title))
                throw new ShiftTitleRequiredException();

            Title = title;
        }


        public void SetInOrderNextShiftId(IShiftExists shiftExists, IInOrderDuplicationChecker inOrderDuplicationChecker, Shift nextShift)
        {

            //if (!shiftExists.Exist(nextShift.Id))
            //    throw new NextShiftNotExistsException();

            //if (inOrderDuplicationChecker.isDuplicate(this.ShiftTemplateId, nextShift.ShiftId))
            //    throw new NextShiftReservedException();

            //if (this.ShiftId == nextShift.ShiftId)
            //    throw new NextShiftRecursiveException();

            //if (this.ShiftTemplateId != nextShift.ShiftTemplateId)
            //    throw new NextShiftTemplateIdConflictException();

            //if ((nextShift.StartTime.TotalSeconds != 0 || nextShift.EndTime.TotalSeconds != 0)
            //        && this.EndTime > nextShift.StartTime)
            //    throw new MissMatchNextShiftStartTimeException();

            //this.NextShift = nextShift.ShiftId;
        }


     
        public string Title { get; set; }
        public Guid ShiftTemplateId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid? NextShiftId { get; set; }
        public ICollection<ShiftTemplate> ShiftTemplates { get; private set; } = new HashSet<ShiftTemplate>();


        public void AddShiftTemplate(string shiftTemplateTitle)
        {
            var shiftTampltes = this.ShiftTemplates.Where(i => i.Title == shiftTemplateTitle).ToList();

            if (shiftTampltes.Count() == 0)
            {
                var shiftTemplate = new ShiftTemplate(shiftTemplateTitle);
                ShiftTemplates.Add(shiftTemplate);
                this.ShiftTemplateId = shiftTemplate.Id;
            }
            else
            {
                this.ShiftTemplateId = shiftTampltes.First().Id;
            }
        }



        public IEnumerable<Expression<Func<Shift, object>>> GetAggregateExpressions()
        {
            //yield return null;
            yield return e => e.ShiftTemplates;
        }
    }
}
