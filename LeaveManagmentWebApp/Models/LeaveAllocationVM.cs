using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentWebApp.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        [Required]
        [Range(1, 50, ErrorMessage = "Invalid Number Entered")]
        public int NumberOfDays { get; set; }
        
        [Required]
        [Display(Name = "Allocation Period")]
        public int Period { get; set; }

        public LeaveTypeVM? LeaveType { get; set; } // you can include another view model as a property,
                                                   // but you cant include another data model as a property
                                                   // never make direct interact view model with data model
    }
}