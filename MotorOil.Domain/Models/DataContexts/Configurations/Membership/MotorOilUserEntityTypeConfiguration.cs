using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotorOil.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorOil.Domain.Models.DataContexts.Configurations
{
    public class MotorOilUserEntityTypeConfiguration : IEntityTypeConfiguration<MotorOilUser>
    {
        public void Configure(EntityTypeBuilder<MotorOilUser> builder)
        {
            builder.ToTable("Users","Membership");
        }
    }
}
