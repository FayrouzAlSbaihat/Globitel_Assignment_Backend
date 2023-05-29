using System.ComponentModel.DataAnnotations;

namespace FayrouzGlobitelAssignmentFullStack.Models
{
    public class CompanyDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Email { set; get; }
        public string Sector_Id { set; get; }
        public string size { get; set; }
    }
}
