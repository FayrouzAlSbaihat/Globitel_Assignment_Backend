using FayrouzGlobitelAssignmentFullStack.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FayrouzGlobitelAssignmentFullStack.data
{
    public class Complain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string DescriptionComplains { get; set; }


        [ForeignKey("applicationUsers")]
        public string? User_Id { get; set; }

        public ApplicationUsers applicationUsers { get; set; }


    }
}
