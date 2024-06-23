using Argus.Platform.Application.Companies.Breanches;
using Argus.Platform.Application.Companies.Companys;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Branches.Dtos;
using Argus.Platform.Controllers.v1.Companies.Dtos;
using Argus.Platform.Core.Companies;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Branches
{
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet(ApiRoutes.Branch.GetAll)]
        public async Task<IActionResult> GetAlBranches()
        {
            var branch = await _branchService.GetAllBranchAsync();
            return Ok(branch);
        }

        [HttpGet(ApiRoutes.Branch.Get)]
        public async Task<IActionResult> GetBranch(Guid id)
        {
            var branch = await _branchService.GetBranchAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            return Ok(branch);
        }

        [HttpPost(ApiRoutes.Branch.Create)]
        public async Task<IActionResult> AddBranch(BranchDto branchDto)
        {

            var branch = branchDto.Adapt<Branch>();

            var addedBranch = await _branchService.AddBranchAsync(branch);
            return CreatedAtAction(nameof(GetBranch), new { id = addedBranch.Id }, addedBranch);
        }

        [HttpPut(ApiRoutes.Branch.Create)]
        public async Task<IActionResult> UpdateBranch(Guid id, BranchDto branchDto)
        {
            var existingBranch = await _branchService.GetBranchAsync(id);
            if (existingBranch == null)
            {
                return NotFound();
            }

            existingBranch = branchDto.Adapt<Branch>();

            var updatedBranch = await _branchService.UpdateBranchAsync(existingBranch);
            return Ok(updatedBranch);
        }
    }
}
