using Framework.Core.Persistence;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace Framework.Persistence
{
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
    }
}
