using Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.ShiftTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace HR.ShiftContext.Infrastructure.Persistence.Shifts.Mapping
{
    public class ShiftMapping : EntityMappingBase<Shift>
    {
        public override void Configure(EntityTypeBuilder<Shift> builder)
        {
            Initial(builder);

            builder.Property(i => i.Title).IsRequired().HasMaxLength(100);
            builder.Property(i => i.ShiftTemplateId).IsRequired();
            builder.Property(i => i.StartTime).IsRequired();
            builder.Property(i => i.EndTime).IsRequired();
            builder.Property(i => i.NextShiftId).HasColumnType(SqlDbType.UniqueIdentifier.ToString())
                .IsRequired(false);

            //builder
            //    .HasOne<ShiftTemplate>()
            //    .WithMany(i => i.)
            //    .HasForeignKey(i => i.ShiftTemplateId)
            //    .HasConstraintName("FK_Shift_ShiftTemplate");

           

            //builder.            HasOne<Customer>()
            //    .WithMany(c => c.Addresses)
            //    .HasForeignKey(a => a.CustomerId)
            //    .HasConstraintName("Fk_Customer_Addresses")
            //    .IsRequired();

            //builder
            //    .HasMany(p => p.ShiftTemplates)
            //    .WithOne(p => p.Shift)
            //    .HasForeignKey(p => p.)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
