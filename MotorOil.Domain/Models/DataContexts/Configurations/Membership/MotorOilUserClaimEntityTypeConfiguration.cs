
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorOil.Domain.Models.Entities.Membership;

namespace MotorOil.Domain.Models.DataContexts.Configurations
{
    public class MotorOilUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<MotorOilUserClaim>
    {
        public void Configure(EntityTypeBuilder<MotorOilUserClaim> builder)
        {
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
