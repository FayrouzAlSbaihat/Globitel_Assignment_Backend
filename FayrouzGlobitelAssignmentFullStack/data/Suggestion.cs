using FayrouzGlobitelAssignmentFullStack.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FayrouzGlobitelAssignmentFullStack.data
{
    public class Suggestion
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Suggestions { get; set; }

        [ForeignKey("applicationUsers")]
        public string? User_Id { get; set; }

        public ApplicationUsers applicationUsers { get; set; }


    }
}
