using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentWebApp.Models
{
    public class LeaveTypeVM // control the data for user to see
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Default Number of Days")] // Annotation
        [Required]
        [Range (1, 25, ErrorMessage = "Please Enter A Valid Number")]
        public int DefaultDays { get; set; }
    }
}
