using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentWebApp.Data
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("LeaveTypeId")]

        public LeaveType LeaveType { get; set; } // what kind of leave type(like vaction type , business type 

        
        public int LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; }

        public string? RequestComments { get; set; }
        
        public bool? Approved { get; set; } // it means is the approval is pendding 

        public bool Cancelled { get; set;}

        public string RequestingEmployeeId { get; set; }


    }
}
