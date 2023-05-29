using FayrouzGlobitelAssignmentFullStack.data;
using FayrouzGlobitelAssignmentFullStack.Models;
using FayrouzGlobitelAssignmentFullStack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FayrouzGlobitelAssignmentFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        ICompanyServices companyServices;
        public CompanyController(ICompanyServices _companyServices) 
        {
            companyServices= _companyServices;
        }


        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("NewCompany")]
        public void NewCompany(CompanyDTO companyDTO)
        {
            companyServices.AddNewCompany(companyDTO);
        }


        [HttpGet]
        [Route("CompanyList")]
        public List<CompanyDTO> CompanyList()
        {
           return companyServices.LoadListCompany();
        }

        [HttpGet]
        [Route("EditCompany")]
        public Company EditCompany(int Id)
        {
            return companyServices.getById(Id);
        }

        [HttpGet]
        [Route("Delete")]
        public void Delete(int Id)
        {
            companyServices.DeleteCompany(Id);
        }

        [HttpPost]
        [Route("UpdateCompany")]
        public void UpdateCompany(CompanyDTO companyDTO)
        {
            companyServices.EditCompany(companyDTO);
        }

        [HttpGet]
        [Route("NumOfCompanies")]
        public int NumOfCompanies()
        {
            List<CompanyDTO>numcompany= companyServices.LoadListCompany();
            return numcompany.Count();
        }


    }
}
