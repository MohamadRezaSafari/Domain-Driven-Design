using Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;
using HR.ShiftContext.Domain.ShiftTemplates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HR.ShiftContext.Infrastructure.Persistence
{
    public class ShiftRepository : RepositoryBase<Shift>, IShiftRepository
    {
        public ShiftRepository(IDbContext dbContext) : base(dbContext)
        {
        }


        public List<Shift> GetShifts(List<Guid> shiftIds)
        {
            return dbContext.Set<Shift>().Where(i => shiftIds.Contains(i.Id)).ToList();
        }


        public void ShiftCreate(Shift shift)
        {
            base.Create(shift);
        }

        public bool Any(Expression<Func<Shift, bool>> expression)
        {
            return dbContext.Set<Shift>().Any(expression);
        }




        public Shift GetShiftById(Guid shiftId)
        {
            return base.Set.SingleOrDefault(s => s.Id == shiftId);
            //return dbContext.Set<Shift>().SingleOrDefault(s => s.Id == shiftId);
        }

        public Shift GetShiftByShiftSegmentId(Guid shiftSegmentId)
        {
            return base.Set
                .Where(i => i.ShiftSegments.Select(a => a.Id).Contains(shiftSegmentId))
                .FirstOrDefault();
            //return dbContext.Set<Shift>()
            //    .Include(i => i.ShiftSegments)
            //    .Where(i => i.ShiftSegments.Select(a => a.Id).Contains(shiftSegmentId))
            //    .FirstOrDefault();
        }

        public bool IsShiftSegmentExist(Guid ShiftSegmentId)
        {
            return dbContext.Set<ShiftSegment>().Any(i => i.Id == ShiftSegmentId);
        }

        protected override IEnumerable<Expression<Func<Shift, object>>> GetAggregateExpression()
        {
            yield return e => e.ShiftSegments;
        }

        public List<ShiftSegment> GetShiftSegments(Guid shiftId)
        {
            return dbContext.Set<ShiftSegment>().Where(i => i.ShiftId == shiftId).ToList();
        }
    }
}
