
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorOil.Domain.Models.Entities.Membership;

namespace MotorOil.Domain.Models.DataContexts.Configurations
{
    public class MotorOilRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<MotorOilRoleClaim>
    {
        public void Configure(EntityTypeBuilder<MotorOilRoleClaim> builder)
        {
            builder.ToTable("RolesClaims", "Membership");
        }
    }
}
