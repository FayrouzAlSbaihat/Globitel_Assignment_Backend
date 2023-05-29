using FayrouzGlobitelAssignmentFullStack.Models;
using FayrouzGlobitelAssignmentFullStack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FayrouzGlobitelAssignmentFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainController : ControllerBase
    {
        IComplainService complainService;
        public ComplainController(IComplainService _complainService) 
        {
           complainService = _complainService;
        }

        [HttpPost]
        [Route("NewComplain")]
        public void NewComplain(ComplainDTO complainDTO) 
        {
            complainService.AddComplain(complainDTO);
        }


        [HttpGet]
        [Route("ComplainsList")]
        public List<ComplainDTO> ComplainsList()
        {
            return complainService.LoadComplains();
        }


        [HttpGet]
        [Route("ComplainsListByEmployee")]
        public List<ComplainDTO> ComplainsListByEmployee(string User_id)
        {
            return complainService.LoadComplainsByEmployee(User_id);
        }


        [HttpPost]
        [Route("SendComplain")]
        public void SendComplain(ComplainDTO complainDTO)
        { 
            complainService.EditComplain(complainDTO);
        }

        [HttpGet]
        [Route("NumOfComplains")]
        public int NumOfComplains()
        {
            List<ComplainDTO>Nocomplains = complainService.LoadComplains();
            return Nocomplains.Count();
        }







    }
}
