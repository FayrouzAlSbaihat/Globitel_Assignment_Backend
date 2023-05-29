using FayrouzGlobitelAssignmentFullStack.data;
using Microsoft.AspNetCore.Identity;

namespace FayrouzGlobitelAssignmentFullStack.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string Name { get; set; }
        //public int Company_Id { get; set; }

        //public List<Complain> complains { get; set; }
    }
}
