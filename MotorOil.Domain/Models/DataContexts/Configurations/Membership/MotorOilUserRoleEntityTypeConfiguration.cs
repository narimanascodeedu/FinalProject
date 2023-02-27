
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorOil.Domain.Models.Entities.Membership;

namespace MotorOil.Domain.Models.DataContexts.Configurations
{
    public class MotorOilUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<MotorOilUserRole>
    {
        public void Configure(EntityTypeBuilder<MotorOilUserRole> builder)
        {
            builder.ToTable("UserRoles", "Membership");
        }
    }
}
