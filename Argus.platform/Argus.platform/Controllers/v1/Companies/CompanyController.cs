using Argus.Platform.Application.Companies.Companys;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Companies.Dtos;
using Argus.Platform.Core.Companies;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Companies
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet(ApiRoutes.Company.GetAll)]
        public async Task<IActionResult> GetAlCompanys()
        {
            var Company = await _companyService.GetAllCompanyAsync();
            return Ok(Company);
        }

        [HttpGet(ApiRoutes.Company.Get)]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _companyService.GetCompanyAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost(ApiRoutes.Company.Create)]
        public async Task<IActionResult> AddCompany(CompanyDto companyDto)
        {

            var company = companyDto.Adapt<Company>();

            var addedCompany = await _companyService.AddCompanyAsync(company);
            return CreatedAtAction(nameof(GetCompany), new { id = addedCompany.Id }, addedCompany);
        }

        [HttpPut(ApiRoutes.Company.Create)]
        public async Task<IActionResult> UpdateStudent(Guid id, CompanyDto companyDto)
        {
            var existingCompany = await _companyService.GetCompanyAsync(id);
            if (existingCompany == null)
            {
                return NotFound();
            }

            existingCompany = companyDto.Adapt<Company>();

            var updatedCompany = await _companyService.UpdateCompanyAsync(existingCompany);
            return Ok(updatedCompany);
        }

    }
}
