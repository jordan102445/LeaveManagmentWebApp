using LeaveManagmentWebApp.Contracts;
using LeaveManagmentWebApp.Data;

namespace LeaveManagmentWebApp.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, iLeaveTypeRepositoty
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
