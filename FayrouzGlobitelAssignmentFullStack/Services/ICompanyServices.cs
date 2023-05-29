using FayrouzGlobitelAssignmentFullStack.data;
using FayrouzGlobitelAssignmentFullStack.Models;

namespace FayrouzGlobitelAssignmentFullStack.Services
{
    public interface ICompanyServices
    {
        public void AddNewCompany(CompanyDTO companyDTO);
        public List<CompanyDTO> LoadListCompany();
        public Company getById(int Company_Id);
        public void DeleteCompany(int Id);
        public void EditCompany(CompanyDTO companyDTO);
    }
}
