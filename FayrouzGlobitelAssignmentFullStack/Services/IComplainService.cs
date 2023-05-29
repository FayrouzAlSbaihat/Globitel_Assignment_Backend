using FayrouzGlobitelAssignmentFullStack.Models;

namespace FayrouzGlobitelAssignmentFullStack.Services
{
    public interface IComplainService
    {
        public void AddComplain(ComplainDTO complainDTO);
        public List<ComplainDTO> LoadComplains();
        public void EditComplain(ComplainDTO complainDTO);
        public List<ComplainDTO> LoadComplainsByEmployee(string User_Id);

    }
}
