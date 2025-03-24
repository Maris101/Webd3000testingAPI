using System.ComponentModel.DataAnnotations;

namespace Webd3000testing
{
    public class Contact
    {

        //This is also where the Validation takes place, and not using if statements...

        //Validation classes: 
        //https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-9.0

        [MaxLength(10, ErrorMessage = "First Name has to be less than 10 characters")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(10, ErrorMessage = "Last Name has to be less than 10 characters")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
