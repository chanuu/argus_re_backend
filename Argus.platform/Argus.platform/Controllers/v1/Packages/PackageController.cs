using Argus.Platform.Application.Customers;
using Argus.Platform.Application.Packages;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Customers.Dtos;
using Argus.Platform.Controllers.v1.Packages.Dtos;
using Argus.Platform.Core.Packages;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Packages
{
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet(ApiRoutes.Package.GetAll)]
        public async Task<IActionResult> GetAlPackage()
        {
            var package = await _packageService.GetAllPackagesAsync();
            return Ok(package);
        }

        [HttpGet(ApiRoutes.Package.Get)]
        public async Task<IActionResult> GetPackage(Guid id)
        {
            var package = await _packageService.GetPackageAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }

        [HttpPost(ApiRoutes.Package.Create)]
        public async Task<IActionResult> AddPackage(PackageDto packageDto)
        {

            var package = packageDto.Adapt<Package>();

            var addedPackage = await _packageService.AddPackageAsync(package);
            return CreatedAtAction(nameof(GetPackage), new { id = addedPackage.Id }, addedPackage);
        }

        [HttpPut(ApiRoutes.Package.Create)]
        public async Task<IActionResult> UpdatePackage(Guid id, PackageDto packageDto)
        {
            var existingPackage = await _packageService.GetPackageAsync(id);
            if (existingPackage == null)
            {
                return NotFound();
            }

            existingPackage = packageDto.Adapt<Package>();

            var updatedPackage = await _packageService.UpdatePackageAsync(existingPackage);
            return Ok(updatedPackage);
        }
    }
}
