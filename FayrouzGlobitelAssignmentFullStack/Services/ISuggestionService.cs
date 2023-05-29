using FayrouzGlobitelAssignmentFullStack.Models;

namespace FayrouzGlobitelAssignmentFullStack.Services
{
    public interface ISuggestionService
    {
        public void AddSuggestion(SuggestionDTO suggestionDTO);
        public List<SuggestionDTO> LoadSuggestion();
        public void Send(SuggestionDTO suggestionDTO);
        public List<SuggestionDTO> ListByEmployee(string User_Id);
    }
}
