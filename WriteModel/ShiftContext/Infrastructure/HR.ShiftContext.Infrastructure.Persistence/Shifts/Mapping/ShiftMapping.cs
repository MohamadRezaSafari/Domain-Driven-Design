using Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.ShiftContext.Infrastructure.Persistence.Shifts.Mapping
{
    public class ShiftMapping : EntityMappingBase<Shift>
    {
        public override void Configure(EntityTypeBuilder<Shift> builder)
        {
            Initial(builder);

            builder.Property(i => i.ShiftId).ValueGeneratedOnAdd();
            builder.Property(i => i.Title).IsRequired().HasMaxLength(100);
            builder.Property(i => i.ShiftTemplateId).IsRequired();
            builder.Property(i => i.StartTime).IsRequired();
            builder.Property(i => i.EndTime).IsRequired();
            builder.Property(i => i.NextShift);
        }
    }
}
