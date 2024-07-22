using Argus.Platform.Application.Companies.Companys;
using Argus.Platform.Application.Features;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Companies.Dtos;
using Argus.Platform.Controllers.v1.Features.DTOs;
using Argus.Platform.Core.Features;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Features
{
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet(ApiRoutes.Company.GetAll)]
        public async Task<IActionResult> GetAlFeatures()
        {
            var feature = await _featureService.GetAllFeaturesAsync();
            return Ok(feature);
        }

        [HttpGet(ApiRoutes.Company.Get)]
        public async Task<IActionResult> GetFeature(Guid id)
        {
            var feature = await _featureService.GetFeatureAsync(id);
            if (feature == null)
            {
                return NotFound();
            }
            return Ok(feature);
        }

        [HttpPost(ApiRoutes.Company.Create)]
        public async Task<IActionResult> AddFeature(FeatureDto featureDto)
        {

            var feature = featureDto.Adapt<Feature>();

            var addedFeature = await _featureService.AddFeatureAsync(feature);
            return CreatedAtAction(nameof(GetFeature), new { id = addedFeature.Id }, addedFeature);
        }

        [HttpPut(ApiRoutes.Company.Create)]
        public async Task<IActionResult> UpdateFeature(Guid id, FeatureDto featureDto)
        {
            var existingFeature = await _featureService.GetFeatureAsync(id);
            if (existingFeature == null)
            {
                return NotFound();
            }

            existingFeature = featureDto.Adapt<Feature>();

            var updatedFeature = await _featureService.UpdateFeatureAsync(existingFeature);
            return Ok(updatedFeature);
        }

    }
}
