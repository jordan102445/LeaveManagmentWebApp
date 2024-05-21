namespace LeaveManagmentWebApp.Models
{
    public class EmployeeLeaveRequestViewVM // view models tolk to view models only
    {
        public EmployeeLeaveRequestViewVM(List<LeaveAllocationVM> leaveAllocations,List<LeaveRequestVM> leaveRequests)
        {
            LeaveAllocations = leaveAllocations;
            LeaveRequests = leaveRequests;
        }
        public List<LeaveAllocationVM> LeaveAllocations { get; set;}

        public List<LeaveRequestVM> LeaveRequests { get; set; }    
    }
}
