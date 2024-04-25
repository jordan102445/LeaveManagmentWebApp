namespace LeaveManagmentWebApp.Models
{
    public class LeaveAllocatiomEditVM : LeaveAllocationVM
    {

        public string EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public EmployeeListVM? Employee { get; set; }
    }
}
