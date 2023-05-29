using FayrouzGlobitelAssignmentFullStack.data;
using FayrouzGlobitelAssignmentFullStack.Models;
using Microsoft.AspNetCore.Identity;

namespace FayrouzGlobitelAssignmentFullStack.Services
{
    public class ComplainService : IComplainService
    {
        SystemContext context;
        UserManager<ApplicationUsers> usermanager;

        public ComplainService(SystemContext _context, UserManager<ApplicationUsers> _usermanager)
        {
            context = _context;
            usermanager = _usermanager;

        }

        public void AddComplain(ComplainDTO complainDTO)
        {
            Complain complain = new Complain()
            {
                Name = complainDTO.Name,
                Phone = complainDTO.Phone,
                DescriptionComplains = complainDTO.DescriptionComplains,

            };
            context.Complains.Add(complain);
            context.SaveChanges();

        }


        public List<ComplainDTO> LoadComplains()
        {
            List<Complain> licomplains = context.Complains.ToList();
            List<ComplainDTO> complains = new List<ComplainDTO>();

            foreach (Complain complain in licomplains)
            {
                ComplainDTO complainDTO = new ComplainDTO()
                {
                    Id = complain.Id,
                    Name = complain.Name,
                    Phone = complain.Phone,
                    DescriptionComplains = complain.DescriptionComplains,
                };
                complains.Add(complainDTO);
            }
            return complains;

        }
        public List<ComplainDTO> LoadComplainsByEmployee(string User_Id)
        {
            //User_Id = usermanager.Users;
            List<Complain> licomplains = context.Complains.Where(x => x.User_Id == User_Id).ToList();
            List<ComplainDTO> complains = new List<ComplainDTO>();

            foreach (Complain complain in licomplains)
            {
                ComplainDTO complainDTO = new ComplainDTO()
                {
                    Id = complain.Id,
                    Name = complain.Name,
                    Phone = complain.Phone,
                    DescriptionComplains = complain.DescriptionComplains,
                };
                complains.Add(complainDTO);
            }
            return complains;

        }
        public void EditComplain(ComplainDTO complainDTO)
        {
            Complain complain = new Complain()
            {
                Id = complainDTO.Id,
                Name = complainDTO.Name,
                Phone = complainDTO.Phone,
                DescriptionComplains = complainDTO.DescriptionComplains,
                User_Id = complainDTO.User_Id
            };

            context.Complains.Attach(complain);
            context.Entry(complain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }



    }
}
