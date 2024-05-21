using LeaveManagmentWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentWebApp.Models
{
    public class AdminLeaveRequestViewVM
    {
        [Display(Name = "Total Number of Requesrs")]

        public int TotalRequests { get; set; }

        [Display(Name = "Approved Requests")]

        public int ApprovedRequests { get; set; }

        [Display(Name = "Pending Requests")]

        public int PendingRequests { get; set; }

        [Display(Name = "Rejected Requests")]

        public int ReqjectedRequests { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set;} // list of all the requests of the system
    }
}
