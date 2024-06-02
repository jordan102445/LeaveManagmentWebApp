using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagmentWebApp.Configuration.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {

                    RoleId = "0tc1dv22-19k1-4215-8075-4f7b0k8fa5c4", // Admin from UserRoleSeed
                    UserId = "d414042k-da1f-4e74-c555-415b07f89b27" // AdminID from UserSeed
                },
                 new IdentityUserRole<string>
                 {


                     RoleId = "0tc1bb22-19k1-7890-8075-4f7b0k8cc5c4", // UserRole from UserRoleSeed
                     UserId = "0kk1dc22-19f1-4216-9876-4f7a0f8fa5b4"  // UserID from UserSeed
                 }
                );



                
        }
    }
}