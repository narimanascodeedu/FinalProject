
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorOil.Domain.Models.Entities.Membership;

namespace MotorOil.Domain.Models.DataContexts.Configurations
{
    public class MotorOilRoleEntityTypeConfiguration : IEntityTypeConfiguration<MotorOilRole>
    {
        public void Configure(EntityTypeBuilder<MotorOilRole> builder)
        {
            builder.ToTable("Roles", "Membership");
        }
    }
}
