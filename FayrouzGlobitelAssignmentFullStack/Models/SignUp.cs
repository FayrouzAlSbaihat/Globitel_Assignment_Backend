using FayrouzGlobitelAssignmentFullStack.data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FayrouzGlobitelAssignmentFullStack.Models
{
    public class SignUp
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        //[ForeignKey("company")]
        //public int Company_Id { get; set; }

        //public Company company { get; set; }
    }
}
