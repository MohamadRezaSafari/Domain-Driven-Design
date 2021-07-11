using System;
using System.Linq.Expressions;

namespace HR.DefinitionContext.Domain.Units.Services
{
    public interface IUnitRepository
    {
        void Create(Unit unit);
        bool Any(Expression<Func<Unit, bool>> expression);
    }
}