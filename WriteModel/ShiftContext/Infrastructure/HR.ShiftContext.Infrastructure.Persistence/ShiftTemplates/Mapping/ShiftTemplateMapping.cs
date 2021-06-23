using Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.ShiftTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.ShiftContext.Infrastructure.Persistence.ShiftTemplates.Mapping
{
    public class ShiftTemplateMapping : EntityMappingBase<ShiftTemplate>
    {
        public override void Configure(EntityTypeBuilder<ShiftTemplate> builder)
        {
            Initial(builder);

            builder.Property(i => i.Title).IsRequired().HasMaxLength(100);

            //builder
            //   .HasOne<Shift>()
            //   .WithMany(i => i.ShiftTemplates)
            //   .HasForeignKey(i => i.Id)
            //   .HasConstraintName("FK_ShiftTemplate_Shift");

            //builder
            //    .HasOne<Shift>()
            //    .WithMany(p => p.ShiftTemplates)
            //    .HasForeignKey(p => p.ShiftId)
            //    .HasConstraintName("FK_Shift_ShiftTemplate");
            //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
