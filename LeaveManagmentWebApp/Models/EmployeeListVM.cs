using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentWebApp.Models
{
    public class EmployeeListVM
    {
        public string Id { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Display(Name = "Data Joined")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]

        public DateTime DateJointed { get; set; }

        [Display(Name = "EmailAddress")]
        public string Email { get; set; }



    }
}
