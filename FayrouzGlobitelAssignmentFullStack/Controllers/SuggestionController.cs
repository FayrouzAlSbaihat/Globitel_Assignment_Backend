using FayrouzGlobitelAssignmentFullStack.Models;
using FayrouzGlobitelAssignmentFullStack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FayrouzGlobitelAssignmentFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {

        ISuggestionService suggestionService;
        public SuggestionController(ISuggestionService _suggestionService)
        {
            suggestionService = _suggestionService;
        }


        [HttpPost]
        [Route("NewSuggestion")]
        public void NewSuggestion(SuggestionDTO suggestionDTO)
        {
            suggestionService.AddSuggestion(suggestionDTO);
        }


        [HttpGet]
        [Route("SuggestionList")]
        //[Authorize(Roles = "Admin")]
        public List<SuggestionDTO> SuggestionList()
        {
            return suggestionService.LoadSuggestion();
        }


        [HttpGet]
        [Route("SuggestionsListByEmployee")]
        //[Authorize(Roles = "Employee")]
        public List<SuggestionDTO> SuggestionsListByEmployee(string User_id)
        {
            return suggestionService.ListByEmployee(User_id);
        }


        [HttpPost]
        [Route("SendSuggestion")]
        public void SendSuggestion(SuggestionDTO suggestionDTO)
        {
            suggestionService.Send(suggestionDTO);
        }


        [HttpGet]
        [Route("NumOfSuggestion")]
        public int NumOfSuggestion()
        {
            List<SuggestionDTO>nosuggestion= suggestionService.LoadSuggestion();
            return nosuggestion.Count();
        }





    }
}
