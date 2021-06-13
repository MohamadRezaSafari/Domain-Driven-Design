using Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;
using HR.ShiftContext.Domain.ShiftTemplates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.ShiftContext.Infrastructure.Persistence
{
    public class ShiftRepository : RepositoryBase<Shift>, IShiftRepository
    {
        public ShiftRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public void ShiftCreate(Shift shift)
        {
            base.Create(shift);
        }

        public List<ShiftTemplate> ShiftTemplateExist(Guid shiftTemplateId)
        {
            return dbContext.Set<ShiftTemplate>().Where(i => i.Id == shiftTemplateId).ToList();
        }

        public void ShiftTermplateCreate(ShiftTemplate shiftTemplate)
        {
            dbContext.Set<ShiftTemplate>().Add(shiftTemplate);
        }
    }
}
