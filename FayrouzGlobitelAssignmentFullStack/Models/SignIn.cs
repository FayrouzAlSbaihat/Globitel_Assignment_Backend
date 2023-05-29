using System.ComponentModel.DataAnnotations;

namespace FayrouzGlobitelAssignmentFullStack.Models
{
    public class SignIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
