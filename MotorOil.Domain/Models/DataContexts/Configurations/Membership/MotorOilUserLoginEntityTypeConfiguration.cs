
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorOil.Domain.Models.Entities.Membership;

namespace MotorOil.Domain.Models.DataContexts.Configurations
{
    public class MotorOilUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<MotorOilUserLogin>
    {
        public void Configure(EntityTypeBuilder<MotorOilUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
