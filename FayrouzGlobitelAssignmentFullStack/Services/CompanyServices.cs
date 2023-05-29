using FayrouzGlobitelAssignmentFullStack.data;
using FayrouzGlobitelAssignmentFullStack.Models;
using Microsoft.AspNetCore.Mvc;

namespace FayrouzGlobitelAssignmentFullStack.Services
{
    public class CompanyServices: ICompanyServices
    {
        SystemContext context;

        public CompanyServices(SystemContext _context)
        {
          context= _context;
        }

        public void AddNewCompany(CompanyDTO companyDTO)

        {
            Company company = new Company()
            {
                //Id = companyDTO.Id,
                Name = companyDTO.Name,
                Phone = companyDTO.Phone,
                Email =companyDTO.Email,
                Sector_Id=companyDTO.Sector_Id,
                size = companyDTO.size
                
            };
            context.Companies.Add(company);
            context.SaveChanges();
        }

        public List<CompanyDTO> LoadListCompany()
        {
            List<Company> licompany = context.Companies.ToList();
            List<CompanyDTO>companies= new List<CompanyDTO>();
            foreach(var company in licompany)
            {
                CompanyDTO companyDTO = new CompanyDTO()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Email=company.Email,
                    Phone = company.Phone,
                    Sector_Id = company.Sector_Id,
                    size = company.size

                };
                companies.Add(companyDTO);
            }
            return companies;
        }


        public Company getById(int Company_Id)
        {
            Company company = context.Companies.Find(Company_Id);
            return company;
        }


        public void DeleteCompany(int Id)
        {
            Company company = context.Companies.Find(Id);
            context.Companies.Remove(company);
            context.SaveChanges();

        }

        public void EditCompany(CompanyDTO companyDTO)
        {
            Company company = new Company()
            {
                Id = companyDTO.Id,
                Name = companyDTO.Name,
                Email = companyDTO.Email,
                Phone = companyDTO.Phone,
                Sector_Id=companyDTO.Sector_Id,
                size=companyDTO.size
            };
            context.Companies.Attach(company);
            context.Entry(company).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }


    }
}
