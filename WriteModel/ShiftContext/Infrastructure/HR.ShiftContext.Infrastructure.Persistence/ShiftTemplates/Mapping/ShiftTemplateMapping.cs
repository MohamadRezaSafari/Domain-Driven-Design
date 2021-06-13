using Framework.Persistence;
using HR.ShiftContext.Domain.ShiftTemplates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.ShiftContext.Infrastructure.Persistence.ShiftTemplates.Mapping
{
    public class ShiftTemplateMapping : EntityMappingBase<ShiftTemplate>
    {
        public override void Configure(EntityTypeBuilder<ShiftTemplate> builder)
        {
            Initial(builder);

            builder.Property(i => i.Title).IsRequired().HasMaxLength(100);
        }
    }
}
