using LeaveManagmentWebApp.Data;

namespace LeaveManagmentWebApp.Models
{
    public class EmployeeAllocationVM : EmployeeListVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
