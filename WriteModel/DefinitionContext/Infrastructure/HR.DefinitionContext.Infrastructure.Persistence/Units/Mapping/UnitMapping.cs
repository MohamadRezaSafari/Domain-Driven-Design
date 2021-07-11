using Framework.Persistence;
using HR.DefinitionContext.Domain.Units;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.DefinitionContext.Infrastructure.Persistence.Units.Mapping
{
    public class UnitMapping: EntityMappingBase<Unit>
    {
        public override void Configure(EntityTypeBuilder<Unit> builder)
        {
            Initial(builder);
            builder.HasIndex(i => i.Title).IsUnique(true);
            builder.Property(i => i.Title).HasMaxLength(100).IsRequired(true);
        }
    }
}