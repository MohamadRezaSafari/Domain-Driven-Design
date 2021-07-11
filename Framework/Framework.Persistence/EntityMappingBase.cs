using Framework.Core.Domain;
using Framework.Core.Persistence;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace Framework.Persistence
{
    //public abstract class EntityMappingBase<TEntity> : IEntityTypeConfiguration<TEntity>
    //    where TEntity : class, IEntityBase
    //{
    public abstract class EntityMappingBase<TEntity> : IEntityTypeConfiguration<TEntity>, IEntityMapping where TEntity : EntityBase
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        protected void Initial(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(i => i.Id)
                .HasColumnType(nameof(SqlDbType.UniqueIdentifier))
                .IsRequired()
                .ValueGeneratedNever();
            builder.HasKey(i => i.Id);

            builder.ToTable(typeof(TEntity).Name, typeof(TEntity).Namespace?.Split('.')[1]);
        }

        //protected void Initial(EntityTypeBuilder<TEntity> builder)
        //{
        //    var typeOfTEntity = typeof(TEntity);
        //    var baseClassName = typeof(EntityBase<>).Name;
        //    if (typeOfTEntity.BaseType != null && typeOfTEntity.BaseType.Name == baseClassName && typeOfTEntity.IsClass)
        //    {
        //        builder.Property("Id")
        //            .HasColumnType(nameof(SqlDbType.BigInt))
        //            .ValueGeneratedNever()
        //            .HasDefaultValueSql("NEXT VALUE FOR shared." + typeof(TEntity).Name);

        //        builder.HasKey("Id");
        //    }

        //    builder.ToTable(typeof(TEntity).Name, typeof(TEntity).Namespace?.Split('.')[1]);
        //}
    }
}
