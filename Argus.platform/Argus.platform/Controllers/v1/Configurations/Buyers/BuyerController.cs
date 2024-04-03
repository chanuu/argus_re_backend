using Argus.Platform.Application.Configurations;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Configurations.Buyers.DTOs;
using Argus.Platform.Core.Configuration;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Configurations.Buyers
{
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;

        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpGet(ApiRoutes.Buyers.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var buyers = await _buyerService.GetAllBuyersAsync();
            return Ok(buyers.Adapt<List<BuyerListDto>>());
        }

        [HttpGet(ApiRoutes.Buyers.Get)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var buyer = await _buyerService.GetBuyerByIdAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }
            return Ok(buyer.Adapt<BuyerDetailDto>());
        }

        [HttpPost(ApiRoutes.Buyers.Create)]
        public async Task<IActionResult> Create([FromBody] BuyerInputDto buyerDto)
        {
            var buyer = buyerDto.Adapt<Buyer>();
            var createdBuyer = await _buyerService.AddBuyerAsync(buyer);
            return CreatedAtAction(nameof(GetById), new { id = createdBuyer.Id }, createdBuyer);
        }

        [HttpPost(ApiRoutes.Buyers.Update)]
        public async Task<IActionResult> Update(Guid id, [FromBody] BuyerUpdateDto buyerDto)
        {
            var buyer = buyerDto.Adapt<Buyer>();
            if (id != buyer.Id)
            {
                return BadRequest();
            }
            var updatedBuyer = await _buyerService.UpdateBuyerAsync(buyer);
            return Ok(updatedBuyer);
        }
    }
}
