using LeaveManagmentWebApp.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentWebApp.Models
{
    public class LeaveRequestVM : LeaveRequestCreateVM
    {

        public int Id { get; set; }

        [Display(Name ="Date Requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Leave Type")]
        public LeaveTypeVM LeaveType { get; set; } // what kind of leave type(like vaction type , business type 
        public bool? Approved { get; set; } // it means is the approval is pendding 

        public bool Cancelled { get; set; }

        public string? RequestingEmployeeId { get; set; }
        public EmployeeListVM Employee {  get; set; }
    }
}
