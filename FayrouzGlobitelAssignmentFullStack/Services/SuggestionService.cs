using FayrouzGlobitelAssignmentFullStack.data;
using FayrouzGlobitelAssignmentFullStack.Models;

namespace FayrouzGlobitelAssignmentFullStack.Services
{
    public class SuggestionService: ISuggestionService
    {
        SystemContext context;
        public SuggestionService(SystemContext _context)
        {
            context = _context;
        }


        public void AddSuggestion(SuggestionDTO suggestionDTO)
        {
            Suggestion suggestion = new Suggestion();
            suggestion.Name = suggestionDTO.Name;
            suggestion.Phone = suggestionDTO.Phone;
            suggestion.Suggestions= suggestionDTO.Suggestions;
            context.Suggestions.Add(suggestion);
            context.SaveChanges();

        }

        public List<SuggestionDTO> LoadSuggestion()
        {
            List<Suggestion> licsuggestion = context.Suggestions.ToList();
            List<SuggestionDTO> suggestions = new List<SuggestionDTO>();

            foreach (Suggestion suggestion in licsuggestion)
            {
                SuggestionDTO suggestionDTO = new SuggestionDTO()
                {
                   Id=suggestion.Id,
                   Name = suggestion.Name,
                   Phone = suggestion.Phone,
                   Suggestions= suggestion.Suggestions,

                };
                suggestions.Add(suggestionDTO);
            }
            return suggestions;

        }

        public List<SuggestionDTO> ListByEmployee(string User_Id)
        {
            List<Suggestion> lisuggestion = context.Suggestions.Where(x => x.User_Id == User_Id).ToList();
            List<SuggestionDTO> suggestions = new List<SuggestionDTO>();

            foreach (Suggestion suggestion in lisuggestion)
            {
                SuggestionDTO suggestionDTO = new SuggestionDTO()
                {
                    Id = suggestion.Id,
                    Name = suggestion.Name,
                    Phone = suggestion.Phone,
                    Suggestions= suggestion.Suggestions,
                };
                suggestions.Add(suggestionDTO);
            }
            return suggestions;

        }

        public void Send(SuggestionDTO suggestionDTO)
        {
            Suggestion suggestion = new Suggestion()
            {
                Id = suggestionDTO.Id,
                Name = suggestionDTO.Name,
                Phone = suggestionDTO.Phone,
                Suggestions=suggestionDTO.Suggestions,
                User_Id = suggestionDTO.User_Id
            };

            context.Suggestions.Attach(suggestion);
            context.Entry(suggestion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }



    }
}
