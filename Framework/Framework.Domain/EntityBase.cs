using Framework.Core.Domain;
using Framework.Core.Persistence;
using System;

namespace Framework.Domain
{
    //public abstract class EntityBase<TEntity> : IEntityBase where TEntity : class
    public abstract class EntityBase
    {
        //private IEntityIdGenerator<TEntity> entityIdGenerator = null;

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        //public long Id { get; private set; }

        //protected void SetIdGenerator(IEntityIdGenerator<TEntity> entityIdGenerator)
        //{
        //    this.entityIdGenerator = entityIdGenerator;
        //}


        //protected void SetId()
        //{
        //    if (entityIdGenerator == null)
        //    {
        //        throw new Exception(
        //            "IEntityIdGenerator is Not Implemented or you forgot to put base(entityIdGenerator)");
        //    }

        //    Id = entityIdGenerator.GetNewId();
        //}


        //protected void SetId(long id)
        //{
        //    Id = id;
        //}
    }
}
