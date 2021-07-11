using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Persistence;
using HR.DefinitionContext.Domain.Units;
using HR.DefinitionContext.Domain.Units.Services;

namespace HR.DefinitionContext.Infrastructure.Persistence.Units
{
    public class UnitRepository: RepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        protected override IEnumerable<Expression<Func<Unit, object>>> GetAggregateExpression()
        {
            return null;
        }

        public void Create(Unit unit)
        {
            base.Create(unit);
        }

        public bool Any(Expression<Func<Unit, bool>> expression)
        {
            return dbContext.Set<Unit>().Any(expression);
        }
    }
}