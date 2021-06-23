using Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;
using HR.ShiftContext.Domain.ShiftTemplates;
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

        //public Shift GetShiftByTitle(string title)
        //{
        //    return dbContext.Set<Shift>()
        //}


        public List<Shift> GetShifts(List<Guid> shiftIds)
        {
            return dbContext.Set<Shift>().Where(i => shiftIds.Contains(i.Id)).ToList();
        }


        public void ShiftCreate(Shift shift)
        {
            base.Create(shift);
        }

        public List<ShiftTemplate> ShiftTemplateExist(Guid shiftTemplateId)
        {
            return dbContext.Set<ShiftTemplate>().Where(i => i.Id == shiftTemplateId).ToList();
        }

        public bool Any(Expression<Func<Shift, bool>> expression)
        {
            return dbContext.Set<Shift>().Any(expression);
        }

        public Shift GetShiftById(Guid shiftId)
        {
            return dbContext.Set<Shift>().SingleOrDefault(s => s.Id == shiftId);
        }

        public void ShiftTermplateCreate(ShiftTemplate shiftTemplate)
        {
            dbContext.Set<ShiftTemplate>().Add(shiftTemplate);
        }

        
    }
}
