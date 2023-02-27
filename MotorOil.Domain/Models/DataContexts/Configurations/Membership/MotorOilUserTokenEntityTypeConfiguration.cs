
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorOil.Domain.Models.Entities.Membership;

namespace MotorOil.Domain.Models.DataContexts.Configurations
{
    public class MotorOilUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<MotorOilUserToken>
    {
        public void Configure(EntityTypeBuilder<MotorOilUserToken> builder)
        {
            builder.ToTable("UserTokens", "Membership");
        }
    }
}
