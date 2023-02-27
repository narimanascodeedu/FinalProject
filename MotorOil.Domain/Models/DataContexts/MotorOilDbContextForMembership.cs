using Microsoft.EntityFrameworkCore;
using MotorOil.Domain.Models.Entities.Membership;

namespace MotorOil.Domain.Models.DataContexts
{
    public partial class MotorOilDbContext {
        
        public DbSet<MotorOilRole> Roles { get; set; }
        public DbSet<MotorOilRoleClaim> RoleClaims { get; set; }
        public DbSet<MotorOilUser> Users{ get; set; }
        public DbSet<MotorOilUserClaim> UserClaims{ get; set; }
        public DbSet<MotorOilUserLogin> UserLogins{ get; set; }
        public DbSet<MotorOilUserRole> UserRoles{ get; set; }
        public DbSet<MotorOilUserToken> UserTokens{ get; set; }

    }
}
