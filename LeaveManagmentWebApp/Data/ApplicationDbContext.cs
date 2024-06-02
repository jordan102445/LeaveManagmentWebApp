using LeaveManagmentWebApp.Configuration.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagmentWebApp.Models;


namespace LeaveManagmentWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var item in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State == EntityState.Added 
            || q.State == EntityState.Modified))
            {
                item.Entity.DataModified = DateTime.Now;

                if(item.State == EntityState.Added)
                {
                   item.Entity.DataCreated = DateTime.Now;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<EmployeeAllocationVM> EmployeeAllocationVM { get; set; } = default!;

        //public DbSet<LeaveManagmentWebApp.Models.EmployeeAllocationVM> EmployeeAllocationVM { get; set; } = default!;
        //public DbSet<LeaveManagmentWebApp.Models.EmployeeAllocationVM> EmployeeAllocationVM { get; set; } = default!; same
        // public DbSet<LeaveManagmentWebApp.Models.EmployeeListVM> EmployeeListVM { get; set; } = default!;
        //Razor created this but it is not needed,because we dont need another data table with employees thats why we comment
        // DbSet properties for your application entities

            public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
